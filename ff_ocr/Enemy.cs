using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ff_ocr {
    class Enemy {
        public List<string> MatchStrings = new List<string>();

        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Level { get; set; }
        public string HP { get; set; }
        public string Attack { get; set; }
        public string HitPercentage { get; set; }
        public string MagicAttack { get; set; }
        public string Speed { get; set; }
        public string Defense { get; set; }
        public string Evasion { get; set; }
        public string MagicDefense { get; set; }
        public string MagicEvasion { get; set; }
        public string GP { get; set; }
        public string Experience { get; set; }
        public string Weaknesses { get; set; }
        public string Absorbs { get; set; }
        public string Resists { get; set; }
        public string Steal { get; set; }
        public string Drop { get; set; }

        public Enemy(XElement e) {
            XElement eFirstRow = e.Element("tr");
            Name = eFirstRow.Element("td").Element("b").Value;

            //

            XElement eSecondRow = eFirstRow.ElementsAfterSelf().First();
            ImageURL = "http://www.finalfantasykingdom.net/" + eSecondRow.Element("td").Element("img").Attribute("src").Value;

            //

            XElement eThirdRow = eSecondRow.ElementsAfterSelf().First();

            XElement eLevel = eThirdRow.Element("td");
            Level = eLevel.Value;

            XElement eHP = eLevel.ElementsAfterSelf().First();
            HP = eHP.Value;

            XElement eAttack = eHP.ElementsAfterSelf().First();
            Attack = eAttack.Value;

            XElement eHitPercentage = eAttack.ElementsAfterSelf().First();
            HitPercentage = eHitPercentage.Value;

            XElement eMagicAttack = eHitPercentage.ElementsAfterSelf().First();
            MagicAttack = eMagicAttack.Value;

            XElement eSpeed = eMagicAttack.ElementsAfterSelf().First();
            Speed = eSpeed.Value;

            XElement eDefense = eSpeed.ElementsAfterSelf().First();
            Defense = eDefense.Value;

            XElement eEvasion = eDefense.ElementsAfterSelf().First();
            Evasion = eEvasion.Value;

            XElement eMagicDefense = eEvasion.ElementsAfterSelf().First();
            MagicDefense = eMagicDefense.Value;

            XElement eMagicEvasion = eMagicDefense.ElementsAfterSelf().First();
            MagicEvasion = eMagicEvasion.Value;

            //

            // skip fourth row
            XElement eFourthRow = eThirdRow.ElementsAfterSelf().First();

            //

            XElement eFifthRow = eFourthRow.ElementsAfterSelf().First();

            XElement eGP = eFifthRow.Element("td");
            GP = eGP.Value;

            XElement eExperience = eGP.ElementsAfterSelf().First();
            Experience = eExperience.Value;

            XElement eWeaknesses = eExperience.ElementsAfterSelf().First();
            StringBuilder sb = new StringBuilder();
            foreach (XElement eImg in eWeaknesses.Elements("img")) {
                sb.Append(eImg.Attribute("src").Value.Replace(".png", "").Replace("4/", "") + ", ");
            }
            if (sb.Length > 0) {
                sb.Remove(sb.Length - 2, 2);
                Weaknesses = sb.ToString();
            }
            else {
                Weaknesses = "(none)";
            }
            

            XElement eAbsorbs = eWeaknesses.ElementsAfterSelf().First();
            sb = new StringBuilder();
            foreach (XElement eImg in eAbsorbs.Elements("img")) {
                sb.Append(eImg.Attribute("src").Value.Replace(".png", "").Replace("4/", "") + ", ");
            }
            if (sb.Length > 0) {
                sb.Remove(sb.Length - 2, 2);
                Absorbs = sb.ToString();
            }
            else {
                Absorbs = "(none)";
            }

            XElement eResists = eAbsorbs.ElementsAfterSelf().First();
            sb = new StringBuilder();
            foreach (XElement eImg in eResists.Elements("img")) {
                sb.Append(eImg.Attribute("src").Value.Replace(".png", "").Replace("4/", "") + ", ");
            }
            if (sb.Length > 0) {
                sb.Remove(sb.Length - 2, 2);
                Resists = sb.ToString();
            }
            else {
                Resists = "(none)";
            }
        }

        public override string ToString() {
            return Name;
        }
    }
}
