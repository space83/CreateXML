using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CreateXML
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateXML_Click(object sender, EventArgs e)
        {
            try
            {
                // load record from db
                var obj = new OneStopEntities();
                var headerData = obj.T_ORDER_HEADER.FirstOrDefault();
                var detailsData = obj.T_ORDER_DETAIL.ToList();

                // write to xml file
                XmlTextWriter writer = new XmlTextWriter("ESSVMI_Sample-TEST.XML", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("WMS");
                writer.WriteStartElement("Order");

                createHeader(writer, headerData);
                createDetails(writer, detailsData);

                writer.WriteEndElement(); // close Order
                writer.WriteEndElement(); // close WMS

                writer.WriteEndDocument(); 
                writer.Close();

                MessageBox.Show("XML File Create ! ");
            }
            catch (Exception ex) { }
        }

        private void writeText(XmlTextWriter writer, string h1, string v1)
        {
            writer.WriteStartElement(h1);
            writer.WriteString(v1);
            writer.WriteEndElement();
        }

        private void createHeader(XmlTextWriter writer, T_ORDER_HEADER h)
        {
            writer.WriteStartElement("Header");

            writeText(writer, "RARefNum", h.RARefNum);
            writeText(writer, "WMSCategory", h.Customer);
            writeText(writer, "CustomerID", h.SupplierName);
            writeText(writer, "CreationDate", h.CreationDate?.ToString("yyyy-MM-dd HH:mm:ss"));
            writeText(writer, "OrderDate", h.OrderDate?.ToString("yyyy-MM-dd HH:mm:ss"));

            writeText(writer, "ExpectedShippedDate", h.ExpShippedDate?.ToString("yyyy-MM-dd HH:mm:ss"));
            writeText(writer, "LastShippedDate", h.LastShippedDate?.ToString("yyyy-MM-dd HH:mm:ss"));
            writeText(writer, "CustomerOrderReference", h.CustomerOrderReference);
            writeText(writer, "CustomerShipmentNo", h.CustomerShipmentNo);
            writeText(writer, "CustomerSONo", h.CustomerSONo);

            writeText(writer, "CustomerInvoiceNo", h.CustomerInvoiceNo);
            writeText(writer, "CustomerReference1", h.CustomerReference1);
            writeText(writer, "CustomerReference2", h.CustomerReference2);
            writeText(writer, "WMSReference1", h.ReferenceInfo1);
            writeText(writer, "WMSReference2", h.ReferenceInfo2);

            writeText(writer, "ShipmentNo", h.ShipmentNo);
            writeText(writer, "DocumentNo", h.DocumentNo);

            // 2 layer
            writer.WriteStartElement("Transportation");
            writeText(writer, "Mode", h.TransportMode);
            writeText(writer, "VehicleType", "");
            writer.WriteEndElement();

            // 3 layer - Carrier
            writer.WriteStartElement("Carrier");
            writeText(writer, "ID", h.CarrierId);
            writeText(writer, "Name", h.CarrierName);
            writeText(writer, "Address", h.CarrierAddress);
            writeText(writer, "Country", "");
            writeText(writer, "PostalCode", "");

            writer.WriteStartElement("Contact");
            writeText(writer, "Sequence", "");
            writeText(writer, "Person", "");
            writeText(writer, "Email", "");
            writeText(writer, "DID", "");
            writeText(writer, "Handphone", "");
            writer.WriteEndElement();
            writer.WriteEndElement();

            // 3 layer - Consignee
            writer.WriteStartElement("Consignee");
            writeText(writer, "ID", h.ConsigneeId);
            writeText(writer, "Name", h.ConsigneeName);
            writeText(writer, "Address", h.ConsigneeAddress);
            writeText(writer, "Country", "");
            writeText(writer, "PostalCode", "");

            writer.WriteStartElement("Contact");
            writeText(writer, "Sequence", "");
            writeText(writer, "Person", "");
            writeText(writer, "Email", "");
            writeText(writer, "DID", "");
            writeText(writer, "Handphone", "");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteEndElement(); // close Header
        }

        private void createDetails(XmlTextWriter writer, List<T_ORDER_DETAIL> d)
        {
            writer.WriteStartElement("Details");

            foreach (var p in d)
                createDetail(writer, p);

            writer.WriteEndElement(); // close Details
        }

        private void createDetail(XmlTextWriter writer, T_ORDER_DETAIL d)
        {
            writer.WriteStartElement("Detail");

            writeText(writer, "LineNo", d.RARefLine.ToString());
            writeText(writer, "SKU", d.SKU);
            writeText(writer, "SKUDescription", d.SKUDescription);
            writeText(writer, "Package", d.Package);
            writeText(writer, "OrderedQty", d.OrderedQty.ToString());

            writeText(writer, "PickedQty", d.PickedQty.ToString());
            writeText(writer, "PickedDate", d.PickedDate?.ToString("yyyy-MM-dd HH:mm:ss"));
            writeText(writer, "ShippedQty", d.ShippedQty.ToString());
            writeText(writer, "ShippedDate", d.ShippedDate?.ToString("yyyy-MM-dd HH:mm:ss"));
            writeText(writer, "ManufactoryDate", d.ManufactoryDate?.ToString("yyyy-MM-dd HH:mm:ss"));

            writeText(writer, "ExpiryDate", d.ExpiryDate?.ToString("yyyy-MM-dd HH:mm:ss"));
            writeText(writer, "FIFODate", d.FIFODate?.ToString("yyyy-MM-dd HH:mm:ss"));
            writeText(writer, "CustomerLotRef1", d.ReferenceInfo1);
            writeText(writer, "CustomerLotRef2", d.ReferenceInfo2);
            writeText(writer, "LineReference1", d.QACode);

            writer.WriteEndElement(); // close Detail
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                var objwebService = new localhost.WebService();
                var doc = new XmlDocument();
                doc.Load("ESSVMI_Sample-TEST.XML");

                string totalShippedQty = objwebService.AnalyzeXML(doc);
                MessageBox.Show("Shipped Qty: " + totalShippedQty);
            }
            catch (Exception ex) { }
        }


    }
}