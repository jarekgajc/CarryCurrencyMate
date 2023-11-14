using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    internal interface IResponse
    {
        bool Success { get; set; }
        List<ResponseError>? Errors { get; set; }

        public static List<string>? GetErrorsDescriptions(IResponse response)
        {
            if (response.Errors == null)
                return null;

            return response.Errors.Select(error => error.Description.ToString()).ToList();
        }
    }
}
