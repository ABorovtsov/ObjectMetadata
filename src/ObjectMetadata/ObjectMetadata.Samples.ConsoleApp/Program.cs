using System;
using AutoMapper;
using GenFu;
using ObjectMetadata.Core;
using ObjectMetadata.Core.Util;
using ObjectMetadata.Samples.Common;

namespace ObjectMetadata.Samples.ConsoleApp
{
    class Program
    {
        private static MyModel _object;

        static void Main(string[] args)
        {
            Initialize();

            CreateObjectWithMetadata();
            ReadObjectWithMetadata();

            Console.WriteLine(new string('=', 10));
            Console.WriteLine("Done");
        }

        private static void Initialize()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<MyModel, MyModel>(); });
        }

        private static void CreateObjectWithMetadata()
        {
            MyModel myModel = A.New<MyModel>();
            _object = Metadata.Inject(myModel);

            var metadata = ((IMetadataAware)_object).Metadata;
            metadata["Hey"] = "Alex";
            metadata["Are you"] = "OK :)?";
        }

        private static void ReadObjectWithMetadata()
        {
            Console.WriteLine($"{nameof(_object.Age)}: {_object.Age}");
            Console.WriteLine($"{nameof(_object.Name)}: {_object.Name}");
            Console.WriteLine($"{nameof(_object.Comment)}: {_object.Comment}");

            Console.WriteLine(Environment.NewLine + "Metadata:");
            Console.WriteLine(new string('-', 10));
            foreach (var keyValue in ((IMetadataAware)_object).Metadata)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
        }
    }
}