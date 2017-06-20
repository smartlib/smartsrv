using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DataMap
{
    public class DataReaderBuilder<T> : IDisposable
    {
        private Dictionary<string, MemberInfo> _maps;

        public DataReaderBuilder()
        {
            _maps = new Dictionary<string, MemberInfo>();
        }

        public IDictionary<string, MemberInfo> Maps
        {
            get
            {
                if (_maps == null) throw new ObjectDisposedException(nameof(Maps));
                return _maps;
            }
        }

        public DataReaderBuilder<T> AddMap(MemberInfo source, string destination)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            Maps.Add(destination, source);

            return this;
        }

        private static MemberInfo GetMemberInfo<P>(Expression<Func<T, P>> get)
        {
            if (get == null) throw new ArgumentNullException(nameof(get));

            MemberExpression exp = null;
            if (get.Body.NodeType == ExpressionType.Convert)
                exp = ((UnaryExpression)get.Body).Operand as MemberExpression;
            else
                exp = get.Body as MemberExpression;
            if (exp == null) throw new ArgumentException($"invalid expression {get}");

            return exp.Member;
        }

        public void Dispose()
        {
            _maps = null;
        }
    }
}
