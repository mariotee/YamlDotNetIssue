using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNetTests.Interfaces;

namespace YamlDotNetTests.Classes
{
    public class Dog : IAnimal
    {
        public string name { get; set; }
        public bool likesBones { get; set; }
    }
}
