using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNetTests.Classes;

namespace YamlDotNetTests
{
    public static class YamlUtil
    {
        private static IDeserializer des = new DeserializerBuilder()
            .WithTagMapping("!" + nameof(Cat), typeof(Cat))
            .WithTagMapping("!" + nameof(Dog), typeof(Dog))
            .WithTagMapping("!" + nameof(Hamster), typeof(Hamster))
            .Build();
        private static ISerializer ser = new SerializerBuilder()
            .WithTagMapping("!" + nameof(Cat), typeof(Cat))
            .WithTagMapping("!" + nameof(Dog), typeof(Dog))
            .WithTagMapping("!" + nameof(Hamster), typeof(Hamster))
            .EnsureRoundtrip()
            .Build();

        public static TObject fromYaml<TObject>(string yaml)
        {
            return des.Deserialize<TObject>(yaml);
        }

        public static TObject fromYamlStream<TObject>(string yaml)
        {
            var stream = new YamlStream();
            stream.Load(new StringReader(yaml));
            //pre processing would go here

            using (var wr = new StringWriter())
            {
                stream.Save(wr, false);

                File.WriteAllText("Desktop-Path",wr.ToString());
                return fromYaml<TObject>(wr.ToString());
            }                        
        }
    }
}
