﻿using System.Collections.Generic;

namespace ItLabs.MyRecipes.Core.Responses
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
