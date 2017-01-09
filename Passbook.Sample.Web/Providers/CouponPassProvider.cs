using System;
using Passbook.Generator;
using Passbook.Generator.Configuration;
using Passbook.Generator.Fields;
using Passbook.Web;

namespace Passbook.Sample.Web.Providers
{
    public class CouponPassProvider : PassProvider
    {
        public override string PassTypeIdentifier => "pass.tomsamcguinness.coupon";

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

            request.AddBarcode(BarcodeType.PKBarcodeFormatPDF417, "01927847623423234234", "UTF-8", "01927847623423234234");

            request.LoadTemplate("Coupon", parameters);

            return request;
        }
    }
}

