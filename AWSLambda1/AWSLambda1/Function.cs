using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Amazon.S3;
using Amazon.S3.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda1
{
    public class Function
    {
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<bool>  FunctionHandler(Submission input, ILambdaContext context)
        {
            try
            {
                using (var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast2))
                {
                    var request = new PutObjectRequest
                    {
                        BucketName = input.Bucket,
                        Key = input.Key,
                        ContentBody = input.Content
                    };
                    var response = await client.PutObjectAsync(request);
                }
                return true;
            }
            catch (Exception ex)
            {
                var logger = context.Logger;
                logger.Log("Exception in PutS3Object:" + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }
    }
}
