using System;
using System.IO;
using System.Net;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://github.com/aws/aws-sdk-net/issues/499
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", AWS_Consts.ACCESS_KEY);
            Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", AWS_Consts.SECRET_ACCESS_KEY);
            Environment.SetEnvironmentVariable("AWS_REGION", "us-east-1");
            // https://docs.aws.amazon.com/AmazonS3/latest/dev/UploadObjSingleOpNET.html
            using(var s3 = new Amazon.S3.AmazonS3Client(Amazon.RegionEndpoint.USEast1)){
                var request = new PutObjectRequest{
                    BucketName = "aws-lightsail",
                    Key = "keyName",
                    FilePath = "/SwiftLanguage.pdf"
                };

                request.Metadata.Add("x-amz-meta-title","swift");
                var response2 = s3.PutObjectAsync(request);
                Console.WriteLine(response2.Result);
            }
        //     var region = "us-east-1";
        //     var request = (HttpWebRequest)WebRequest.Create(string.Format("https://aws-lightsail.s3.{0}.amazonaws.com",region));
        //     request.Method = "POST";
        //     request.Headers.Add("AWSAccessKeyId",AWS_Consts.ACCESS_KEY);
            
        //     using(var response = (HttpWebResponse)request.GetResponse()){
        //         if(response.StatusCode==HttpStatusCode.OK){
        //             using(var stream = response.GetResponseStream()){
        //                 Console.WriteLine(new StreamReader(stream).ReadToEnd());
        //             }
        //         }
        //         else throw new WebException("Error: "+response.StatusCode);
        //     }
        }
    }
}
