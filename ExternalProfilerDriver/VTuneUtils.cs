// Python Tools for Visual Studio
// Copyright(c) 2018 Intel Corporation.  All rights reserved.
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExternalProfilerDriver
{
    public static class Utils
    {
        // from an idea in https://github.com/dotnet/corefx/issues/3093
        public static IEnumerable<T> Emit<T>(T element)
        {
          return Enumerable.Repeat(element, 1);
        }
    }

    public struct Option<T>
    {
        public bool HasValue { get; }
               T    Value    { get; }
        
        /// <summary>
        /// This may seem a bit weird for an `Option` constructor, the
        /// implementation only recognizes the `Value` as valid if `HasValue` has
        /// been set to `true`.
        /// </summary>        
        internal Option(T _value, bool _hasValue)
        {
            this.Value = _value;
            this.HasValue = _hasValue;
        }

        public T GetOrElse(T otherwise)
        {
            return (this.HasValue? this.Value : otherwise);
        }

        public override string ToString()
        {
            if (!HasValue) {
                return "This Option is None";
            }
            return $"Optional has value: {Value}";
        }
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value) { return new Option<T>(value, true); }
        public static Option<T> None<T>() { return new Option<T>(default(T), false); }
    }
}