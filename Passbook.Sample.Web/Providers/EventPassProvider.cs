using System;
using Passbook.Generator;
using Passbook.Generator.Configuration;
using Passbook.Generator.Fields;
using Passbook.Web;

namespace Passbook.Sample.Web.Providers
{
    public class EventPassProvider : PassProvider
    {
        public override string PassTypeIdentifier => "pass.tomsamcguinness.events";

        public override bool IsUpdating()
        {
            return false;
        }

        public override PassGeneratorRequest GetPass(string serialNumber)
        {
            var request = new PassGeneratorRequest
            {
                PassTypeIdentifier = PassTypeIdentifier,
                SerialNumber = Guid.NewGuid().ToString("D")
            };


            var parameters = new TemplateModel();

            parameters.AddField("event", FieldAttribute.Value, "Jeff Wayne's War of the Worlds");

            var eventDate = DateTime.Now.AddDays(1);

            parameters.AddField("doors-open", FieldAttribute.Value,
                new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, 20, 30, 00));
            parameters.AddField("seating-section", FieldAttribute.Value, 10);

            request.AddBarcode(BarcodeType.PKBarcodeFormatPDF417, "01927847623423234234", "iso-8859-1",
                "01927847623423234234");

            request.LoadTemplate("Event", parameters);

            return request;
        }
    }
}