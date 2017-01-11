using System;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain.Responses
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            IsSuccessful = true;
            Errors = new List<string>();
        }
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
    }
}
