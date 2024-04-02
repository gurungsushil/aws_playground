using Amazon.CDK;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.S3;
using Constructs;

namespace Test
{
    public class TestStack : Stack
    {
        internal TestStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here
            // Creates S3 Bucket
            new Bucket(this, "MyFirstBucket", new BucketProps
            {
                Versioned = true
            });

            // Create DynamoDB Table
            new Table(this, "MyFirstDynamoDBTable", new TableProps
            {
                PartitionKey = new Attribute { Name = "PK", Type = AttributeType.STRING },
                SortKey = new Attribute { Name = "SK", Type = AttributeType.STRING },
                BillingMode = BillingMode.PAY_PER_REQUEST
            });

            var lambda = new Function(this, "MyLambdaFunction", new FunctionProps
            {
                Runtime = Runtime.DOTNET_6,
                Code = Code.FromAsset(@"C:\Users\DELL\Documents\Project\test\src\AWSLambda1"), // Folder containing your Lambda function code
                Handler = "AWSLambda1::AWSLambda1.Function::FunctionHandler",
            });

        }
    }
}
