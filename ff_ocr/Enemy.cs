using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ff_ocr {
    class Enemy {
        public List<string> MatchStrings = new List<string>();
        public bool Verified { get; set; }

        public string Name { get; set; }
        public string ImagePath { get; set; }
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

        public string HP2 { get; set; }
        public string GP2 { get; set; }
        public string Experience2 { get; set; }

        public XElement ToElement() {
            XElement e = new XElement("enemy");
            e.Add(new XElement("name", Name));
            e.Add(new XElement("verified", Verified.ToString().ToLower()));
            e.Add(new XElement("match_strings", MatchStrings.Select(x => new XElement("match_string", x))));
            e.Add(new XElement("level", Level));
            e.Add(new XElement("hp", HP));
            e.Add(new XElement("attack", Attack));
            e.Add(new XElement("hit_percentage", HitPercentage));
            e.Add(new XElement("magic_attack", MagicAttack));
            e.Add(new XElement("speed", Speed));
            e.Add(new XElement("defense", Defense));
            e.Add(new XElement("evasion", Evasion));
            e.Add(new XElement("magic_defense", MagicDefense));
            e.Add(new XElement("magic_evasion", MagicEvasion));
            e.Add(new XElement("gp", GP));
            e.Add(new XElement("experience", Experience));
            e.Add(new XElement("weaknesses", Weaknesses));
            e.Add(new XElement("absorbs", Absorbs));
            e.Add(new XElement("resists", Resists));
            e.Add(new XElement("image_path", ImagePath));

            e.Add(new XElement("hp2", HP2));
            e.Add(new XElement("gp2", GP2));
            e.Add(new XElement("experience2", Experience2));
            return e;
        }

        public Enemy(XElement e) {
            Name = e.Element("name").Value;
            MatchStrings = e.Element("match_strings").Elements("match_string").Select(x => x.Value.ToLower().Replace(" ", "")).ToList();
            Verified = bool.Parse(e.Element("verified").Value);
            Level = e.Element("level").Value;
            HP = e.Element("hp").Value;
            Attack = e.Element("attack").Value;
            HitPercentage = e.Element("hit_percentage").Value;
            MagicAttack = e.Element("magic_attack").Value;
            Speed = e.Element("speed").Value;
            Defense = e.Element("defense").Value;
            Evasion = e.Element("evasion").Value;
            MagicDefense = e.Element("magic_defense").Value;
            MagicEvasion = e.Element("magic_evasion").Value;
            GP = e.Element("gp").Value;
            Experience = e.Element("experience").Value;
            Weaknesses = e.Element("weaknesses").Value;
            Absorbs = e.Element("absorbs").Value;
            Resists = e.Element("resists").Value;
            ImagePath = e.Element("image_path").Value;

            XElement eHP2 = e.Element("hp2");
            if (eHP2 != null) { HP2 = eHP2.Value; }
            XElement eGP2 = e.Element("gp2");
            if (eGP2 != null) { GP2 = eGP2.Value; }
            XElement eExperience2 = e.Element("experience2");
            if (eExperience2 != null) { Experience2 = eExperience2.Value; }

            MatchStrings.Add(Name.Replace("B", "E").Replace("m", "n").Replace("l", "").Replace("-", "").Replace("M", "h").Replace(" ", "").ToLower());
            MatchStrings.Add(Name.Replace("B", "E").Replace("l", "").Replace("-", "").Replace("M", "h").Replace(" ", "").ToLower());

            MatchStrings = MatchStrings.Distinct().ToList();
        }

        public string FullString {
            get {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Name: " + Name);
                sb.AppendLine("Level: " + Level);
                sb.AppendLine("HP: " + HP);
                sb.AppendLine("HP2: " + HP2);
                sb.AppendLine("Attack: " + Attack);
                sb.AppendLine("Hit Percentage: " + HitPercentage);
                sb.AppendLine("Magic Attack: " + MagicAttack);
                sb.AppendLine("Speed: " + Speed);
                sb.AppendLine("Defense: " + Defense);
                sb.AppendLine("Evasion: " + Evasion);
                sb.AppendLine("Magic Defense: " + MagicDefense);
                sb.AppendLine("Magic Evasion: " + MagicEvasion);
                sb.AppendLine("GP: " + GP);
                sb.AppendLine("GP2: " + GP2);
                sb.AppendLine("Experience: " + Experience);
                sb.AppendLine("Experience2: " + Experience2);
                sb.AppendLine("Weaknesses: " + Weaknesses);
                sb.AppendLine("Absorbs: " + Absorbs);
                sb.AppendLine("Resists: " + Resists);
                return sb.ToString();
            }
        }

        public override string ToString() {
            return Name;
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (obj == DBNull.Value) { return false; }
            Enemy compare = (Enemy)obj;

            return MatchStrings.Contains(compare.Name.ToLower());
        }
    }
}
