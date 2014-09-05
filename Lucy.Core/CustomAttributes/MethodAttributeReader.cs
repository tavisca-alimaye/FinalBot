using Lucy.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.CustomAttributes
{
    public class MethodAttributeReader
    {

        public List<Attribute> GetCommandArgumentAttributes(string methodName, Type className)
        {
            List<Attribute> attributes = new List<Attribute>();
            MemberInfo[] methodInfoDetails = className.GetMethods();
            if (methodInfoDetails.Any(method => (method.Name == methodName)))
                attributes = ((Attribute[])methodInfoDetails.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandArgumentAttribute), false)).ToList();

            return attributes;
        }

        public List<Attribute> GetCommandAttributes(string methodName, Type className)
        {
            List<Attribute> attributes = new List<Attribute>();
            MemberInfo[] methodInfoDetails = className.GetMethods();
            if (methodInfoDetails.Any(method => (method.Name == methodName)))
                attributes = ((Attribute[])methodInfoDetails.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandAttribute), false)).ToList();

            return attributes;
        }

        public List<Attribute> GetCommandReturnsAttributes(string methodName, Type className)
        {
            List<Attribute> attributes = new List<Attribute>();
            MemberInfo[] methodInfoDetails = className.GetMethods();
            if (methodInfoDetails.Any(method => (method.Name == methodName)))
                attributes = ((Attribute[])methodInfoDetails.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandReturnsAttribute), false)).ToList();

            return attributes;
        }

        public List<Attribute> GetAttributes(string methodName, Type className)
        {
            List<Attribute> attributes = new List<Attribute>();

            attributes = attributes.Concat(this.GetCommandArgumentAttributes(methodName, className)).ToList();
            attributes = attributes.Concat(this.GetCommandAttributes(methodName, className)).ToList();
            attributes = attributes.Concat(this.GetCommandReturnsAttributes(methodName, className)).ToList();

            return attributes;
        }

        public List<Attribute> GetAttributesOfAllMethodsFromClass(List<Type> classNameList)
        {
            List<Attribute> attributes = new List<Attribute>();

            foreach (Type className in classNameList)
            {
                MemberInfo[] methodInfoDetails = className.GetMethods();
                foreach (var method in methodInfoDetails)
                    attributes = attributes.Concat(this.GetAttributes(method.Name, className)).ToList();
            }
            return attributes;

        }


    }
}
