using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XmlDiffLib;

namespace XMLComparionApps
{
    class Program
    {

        static void Main(string[] args)
        {
            var sourceXml =
                File.ReadAllText(@"C:\Samples\XMLComparionApps\XMLComparionApps\41.xml");
            var targetXml =
                File.ReadAllText(@"C:\Samples\XMLComparionApps\XMLComparionApps\42.xml");

            //var sourceXml =
            //    File.ReadAllText(@"C:\Samples\XMLComparionApps\XMLComparionApps\782100_B__Chassi_20190307_194830_915.xml");
            //var targetXml =
            //    File.ReadAllText(@"C:\Samples\XMLComparionApps\XMLComparionApps\782100_B__Chassi_20190318_195515_659.xml");

            var diffOptions = new XmlDiffOptions
            {
                IgnoreAttributeOrder = false,
                TwoWayMatch = true,
                IgnoreChildOrder = true,
                IgnoreCase = true,
                IgnorePrefix = false
            };

            var outputMatch = new List<ResultDto>();

            CompareXmls(sourceXml, targetXml, diffOptions, out outputMatch);
            ProcessOutput(outputMatch);
            Console.ReadLine();
        }

        private static void CompareXmls(string sourceXml, string targetXml, XmlDiffOptions diffOptions, out List<ResultDto> outputSourceToTarget)
        {
            try
            {
                outputSourceToTarget = null;
                var diff1 = new XmlDiff(sourceXml, targetXml);

                diff1.CompareDocuments(diffOptions);

                if (diff1.DiffNodeList.Count > 0)
                {
                    Console.WriteLine(diff1.ToString());
                    var dataList = diff1.DiffNodeList.Select(z => z).OrderBy(z => z.DiffId).ToList();

                    var resultList = new List<ResultDto>();
                    foreach (var record in dataList)
                    {
                        MakeResult(record, resultList);
                    }

                    var resultsTobeDisplayed = resultList.Where(x => x.NodeType != "Node").ToList();

                    foreach (var record in resultsTobeDisplayed)
                    {
                        var initialDescription = "";
                        initialDescription = MakeDescription(record, initialDescription);
                        var completeDescription = new StringBuilder();
                        completeDescription.Append("DiffType:");
                        completeDescription.Append(initialDescription);
                        completeDescription.Append(record.DiffType);
                        completeDescription.Append(" ; Xpath : " + record.XPath + " ; " +
                                                   record.Description);
                        record.ResultantOutput = completeDescription.ToString();
                        //Console.WriteLine(completeDescription);
                    }

                    outputSourceToTarget = resultsTobeDisplayed;
                }
            }
            catch (Exception ex)
            {
                outputSourceToTarget = null;
            }
        }

        static void MakeResult(XmlDiffNode xmlDiffNode, List<ResultDto> resultDtos, ResultDto parent = null)
        {
            string fromValue = string.Empty;
            string toValue = string.Empty;

            SplitDescription(xmlDiffNode.Description, out fromValue, out toValue);

            var result = new ResultDto
            {
                Id = Guid.NewGuid(),
                XPath = xmlDiffNode.XPath,
                Description = xmlDiffNode.Description,
                DiffType = xmlDiffNode.DiffType.ToString(),
                DiffId = xmlDiffNode.DiffId,
                NodeType = xmlDiffNode.DiffNodeType.ToString(),
                FromValue = fromValue,
                ToValue = toValue,
                Parent = parent
            };

            if (parent == null)
            {
                if (xmlDiffNode.DiffType == XmlDiffNode.DiffTypes.Added)
                    result.IsRootInsert = true;
            }
            else
            {
                result.IsRootInsert = parent.IsRootInsert;
            }

            resultDtos.Add(result);

            if (xmlDiffNode.Descendants != null && xmlDiffNode.Descendants.Count > 0)
            {
                foreach (var descendant in xmlDiffNode.Descendants)
                {
                    MakeResult(descendant, resultDtos, result);
                }
            }
        }

        static string MakeDescription(ResultDto current, string description)
        {
            if (current.Parent != null)
            {
                description = current.Parent.DiffType + " --> " + description;

                if (current.Parent.Parent != null)
                {
                    MakeDescription(current.Parent, description);
                }
            }

            return description;
        }

        static void SplitDescription(string description, out string fromValue, out string toValue)
        {
            var result = description.Split('|');
            if (result.Length > 1)
            {
                var descValue = result[1].Split('=', '>');
                fromValue = descValue[0].Trim();
                toValue = descValue[2].Trim();
            }
            else
            {
                fromValue = String.Empty;
                toValue = String.Empty;
            }
        }

        static void ProcessOutput(List<ResultDto> outputTwoWayMatch)
        {
            var addedRecords = (from x in outputTwoWayMatch
                                where (x.ResultantOutput.Contains("DiffType:Added") || x.IsRootInsert)
                                select x).ToList();

            var removedRecords = (from x in outputTwoWayMatch
                                  where (x.ResultantOutput.Contains("DiffType:Removed") && !x.IsRootInsert)
                                  select x).ToList();

            var changedRecords = (from x in outputTwoWayMatch
                                  where x.ResultantOutput.Contains("Changed")
                                  select x).ToList();

            Console.WriteLine("*************************Added Records*********************************");

            foreach (var addedRecord in addedRecords)
            {
                //check if removed value exists equivalent to this add
                var equivalentRecord = removedRecords.FirstOrDefault(x => x.FromValue == addedRecord.ToValue &&
                                                                          x.ToValue == addedRecord.FromValue);

                if (addedRecord.FromValue != null && addedRecord.ToValue != null && equivalentRecord != null)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(addedRecord.FromValue))
                {
                    Console.WriteLine("Added Xpath:" + addedRecord.XPath + "; Added value: " + addedRecord.FromValue);
                }
                else
                {
                    Console.WriteLine("Added attribute in Xpath:" + addedRecord.XPath);
                }

            }

            Console.WriteLine("*************************Removed Records*********************************");


            foreach (var record in removedRecords)
            {
                //check if removed value exists equivalent to this add
                var equivalentRecord = addedRecords.FirstOrDefault(x => x.FromValue == record.ToValue &&
                                                                          x.ToValue == record.FromValue);

                if (record.FromValue != null && record.ToValue != null && equivalentRecord != null)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(record.FromValue))
                {
                    Console.WriteLine("Removed value in Xpath:" + record.XPath + "; Removed value: " + record.FromValue);
                }
                else
                {
                    Console.WriteLine("Removed attribute in Xpath:" + record.XPath);
                }

            }

            Console.WriteLine("*************************Modified Records*********************************");

            foreach (var record in changedRecords)
            {
                if (record.ResultantOutput.Contains("DiffType:Changed ;"))
                {
                    Console.WriteLine("Modified attribute in Xpath:" + record.XPath + " ; FromValue:" + record.FromValue +
                                      " --> ToValue:" + record.ToValue);
                }

                if (record.ResultantOutput.Contains("Removed --> Changed"))
                {
                    //check if you have alternative add
                    var equivalentRecord = addedRecords.FirstOrDefault(x => x.FromValue == record.ToValue &&
                                                                            x.ToValue == record.FromValue);

                    if (equivalentRecord != null)
                    {
                        Console.WriteLine("Modified attribute in Xpath:" + record.XPath + " ; FromValue:" + record.FromValue +
                                          " --> ToValue:" + record.ToValue);
                    }
                }

                if (record.ResultantOutput.Contains("Added --> Changed"))
                {
                    continue;
                }
            }

        }

    }

}
