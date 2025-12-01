using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tx2
{
    class DataUtils
    {
        XmlDocument doc;
        XmlElement root;
        string fileName;

        public DataUtils(string filePath)
        {
            doc = new XmlDocument();
            fileName = filePath;
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void them(lophoc lophoc)
        {
            XmlElement lop = doc.CreateElement("lophoc");
            XmlElement malop = doc.CreateElement("malop");
            XmlElement phonghoc = doc.CreateElement("phonghoc");
            XmlElement sinhvien = doc.CreateElement("sinhvien");
            XmlElement masv = doc.CreateElement("masv");
            XmlElement hoten = doc.CreateElement("hoten");
            XmlElement diachi = doc.CreateElement("diachi");

            malop.InnerText = lophoc.malop;
            phonghoc.InnerText = lophoc.phonghoc;
            hoten.InnerText = lophoc.hoten;
            diachi.InnerText = lophoc.diachi;

            sinhvien.SetAttribute("masv", lophoc.masv);

            lop.AppendChild(malop);
            lop.AppendChild(phonghoc);
            lop.AppendChild(sinhvien);
            sinhvien.AppendChild(hoten);
            sinhvien.AppendChild(diachi);

            root.AppendChild(lop);
            doc.Save(fileName);
        }

        public bool sua(lophoc lophoc)
        {
            XmlNode node = root.SelectSingleNode($"lophoc[sinhvien/@masv='{lophoc.masv}']");
            if (node != null)
            {
                XmlElement lop = doc.CreateElement("lophoc");
                XmlElement malop = doc.CreateElement("malop");
                XmlElement phonghoc = doc.CreateElement("phonghoc");
                XmlElement sinhvien = doc.CreateElement("sinhvien");
                XmlElement masv = doc.CreateElement("masv");
                XmlElement hoten = doc.CreateElement("hoten");
                XmlElement diachi = doc.CreateElement("diachi");

                malop.InnerText = lophoc.malop;
                phonghoc.InnerText = lophoc.phonghoc;
                hoten.InnerText = lophoc.hoten;
                diachi.InnerText = lophoc.diachi;

                sinhvien.SetAttribute("masv", lophoc.masv);

                lop.AppendChild(malop);
                lop.AppendChild(phonghoc);
                lop.AppendChild(sinhvien);
                sinhvien.AppendChild(hoten);
                sinhvien.AppendChild(diachi);

                root.ReplaceChild(lop, node);
                doc.Save(fileName);
                return true;
            }
            return false;
        }

        public List<lophoc> hienthi()
        {
            List<lophoc> list = new List<lophoc>();
            XmlNodeList nodes = root.SelectNodes("lophoc");

            foreach(XmlNode node in nodes)
            {
                list.Add(new lophoc
                {
                    malop = node.SelectSingleNode("malop").InnerText,
                    phonghoc = node.SelectSingleNode("phonghoc").InnerText,
                    hoten = node.SelectSingleNode("sinhvien/hoten").InnerText,
                    diachi = node.SelectSingleNode("sinhvien/diachi").InnerText,
                    masv = node.SelectSingleNode("sinhvien").Attributes["masv"].Value,
                });
            }
            return list;
        }

        public bool xoa(string id)
        {
            XmlNode node = root.SelectSingleNode($"lophoc[sinhvien/@masv='{id}']");
            if (node != null)
            {
                root.RemoveChild(node);
                doc.Save(fileName);
                return true;
            }
            return false;
        }

        public List<lophoc> timKiem(string phonghoc)
        {
            List<lophoc> list = new List<lophoc>();
            XmlNodeList nodes = root.SelectNodes($"lophoc[phonghoc='{phonghoc}']");

            foreach (XmlNode node in nodes)
            {
                list.Add(new lophoc
                {
                    malop = node.SelectSingleNode("malop").InnerText,
                    phonghoc = node.SelectSingleNode("phonghoc").InnerText,
                    hoten = node.SelectSingleNode("sinhvien/hoten").InnerText,
                    diachi = node.SelectSingleNode("sinhvien/diachi").InnerText,
                    masv = node.SelectSingleNode("sinhvien").Attributes["masv"].Value,
                });
            }
            return list;
        }

        public int demSoSinhVien()
        {
            XmlNodeList nodes = root.SelectNodes("lophoc/sinhvien");
            return nodes.Count;
        }
    }
}
