using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FortHelper
{
    public class LoadWeaponWebsite
    {
        public string sWeapon { get; set; }
        public string sPerk1 { get; set; }
        public string sPerk2 { get; set; }
        public string sPerk3 { get; set; }
        public string sPerk4 { get; set; }
        public string sPerk5 { get; set; }

        private string _sPlayer;

        public LoadWeaponWebsite(string sPlayer)
        {
            _sPlayer = sPlayer;
        }

        public List<LoadWeaponWebsite> GetAllRangeWeapon()
        {
            List<LoadWeaponWebsite> listInventory = new List<LoadWeaponWebsite>();

            DataSet dsPerks = DBWeapons.GetPerksWebsite();
            DataSet dsWeapon = DBWeapons.GetWeapon();
            DataSet dsRangedInventory = CreateDataSetInventory();

            DataRow newCustomersRow = dsWeapon.Tables[0].NewRow();

            WebClient wClient = new WebClient();
            string strSource = wClient.DownloadString($"https://www.stormshield.one/pve/stats/{_sPlayer}/sch");

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(strSource);

            var htmlBody = htmlDoc.DocumentNode.SelectNodes("//tr ");

            for (int i = 1; i < htmlBody.Count; i++)
            {
                string sWeaponName = htmlBody[i].ChildNodes[3].InnerText; //Name
                string sAllPerks = htmlBody[i].ChildNodes[3].InnerHtml; //all Perks
                //var htmlTest3 = htmlBody[i].ChildNodes[9].InnerText;

                string sPattern = @"aid_[\w]*";
                Regex rgx = new Regex(sPattern, RegexOptions.IgnoreCase);
                string[] asPerks = Regex.Matches(sAllPerks, sPattern).Cast<Match>().Select(m => m.Value).ToArray();

                //Search Range Weapon
                DataRow[] foundRows = dsWeapon.Tables[0].Select($"Name = '{sWeaponName.Replace("&#39;", "''")}'"); //two '' for find
                if(foundRows.Length > 0)
                {
                    DataRow row = dsRangedInventory.Tables[0].NewRow();
                    row[0] = sWeaponName.Replace("&#39;", "'");
                    for (int iPerk = 1; iPerk <= asPerks.Length; iPerk++)
                    {
                        foundRows = dsPerks.Tables[0].Select($"PerkName = '{asPerks[iPerk - 1]}'");
                        if (foundRows.Length > 0)
                        {
                            string sPerkName = foundRows[0]["Description"].ToString();
                            row[iPerk] = sPerkName; 
                        }
                    }
                    dsRangedInventory.Tables[0].Rows.Add(row);
                    listInventory.Add(new LoadWeaponWebsite(_sPlayer)
                    {
                        sWeapon = row[0].ToString(),
                        sPerk1 = row[1].ToString(),
                        sPerk2 = row[2].ToString(),
                        sPerk3 = row[3].ToString(),
                        sPerk4 = row[4].ToString(),
                        sPerk5 = row[5].ToString()
                    });
                }
            }

            return listInventory;
        }

        private DataSet CreateDataSetInventory()
        {
            DataSet dsTemp = new DataSet();
            dsTemp.Tables.Add();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Weapon";
            dsTemp.Tables[0].Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Perk 1";
            dsTemp.Tables[0].Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Perk 2";
            dsTemp.Tables[0].Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Perk 3";
            dsTemp.Tables[0].Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Perk 4";
            dsTemp.Tables[0].Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Perk 5";
            dsTemp.Tables[0].Columns.Add(column);

            return dsTemp;
        }
    }
}
