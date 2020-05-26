using System;
using System.Text.RegularExpressions;

namespace Microservices.Commands.Domain.Base.ValueObjects.General.Location.ZipCodes.Brazilian
{
    public class BrazilianZipCode : ZipCode
    {
        public const short CodeMaxLength = 8;

        public BrazilianZipCode(string code)
            : base(code)
        {
        }

        public override string ToString() => Convert.ToUInt64(Code).ToString(@"00000\-000");

        protected override bool Validate(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;

            var regex = new Regex(@"\d{5}[-\s]?\d{3}");
            return regex.IsMatch(code);
        }
    }
}