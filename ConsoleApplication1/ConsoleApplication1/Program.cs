using System;
using ConsoleApplication1.model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace model
{
    class Program
    {
        static void Main(string[] args)
        {
            //var nodes = findOpenData();
            //showOpenData(nodes);
            //nodes.ForEach(i =>
            //{
            //    sql.Insert(i);
            //});
            var nodes2 = sql.DataOut();
            showOpenData(nodes2);
            Console.ReadKey();
        }

        static List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var xml = XElement.Load(@"deadfactory.xml");
            var nodes = xml.Descendants("row_item").ToList();
            /*
            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                OpenData item = new OpenData();

                item.名稱 = getValue(node, "名稱");
                item.鄉鎮市別 = getValue(node, "鄉鎮市別");
                item.地址 = getValue(node, "地址");
                item.聯絡單位 = getValue(node, "聯絡單位");
                item.電話 = getValue(node, "電話");


                result.Add(item);

            }*/
            nodes.ToList()
                .ForEach(node =>
            {
                OpenData item = new OpenData();

                item.名稱 = getValue(node, "名稱");
                item.鄉鎮市別 = getValue(node, "鄉鎮市別");
                item.地址 = getValue(node, "地址");
                item.聯絡單位 = getValue(node, "聯絡單位");
                item.電話 = getValue(node, "電話");
                result.Add(item);
            });
            return result;
        }

        private static string getValue(XElement node, string header)
        {
            return node.Element(header)?.Value?.Trim();
        }

        public static void showOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(string.Format("登記在宜蘭縣的殯葬設施，總共有{0}家", nodes.Count));
            nodes.GroupBy(node => node.名稱).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var allDatas = group.ToList();
                    var message = $"名稱為:{key}的殯葬設施有{allDatas.Count()}家";
                    Console.WriteLine(message);
                });


        }
    }
}