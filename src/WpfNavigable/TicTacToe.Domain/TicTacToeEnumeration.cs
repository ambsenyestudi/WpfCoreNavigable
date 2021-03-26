using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TicTacToe.Domain
{
    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    public abstract class TicTacToeEnumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected TicTacToeEnumeration(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : TicTacToeEnumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not TicTacToeEnumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((TicTacToeEnumeration)other).Id);
    }
}
