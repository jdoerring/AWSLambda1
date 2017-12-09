using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSLambda1
{
    public class Submission
    {
        public string Bucket { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }
    }
}
