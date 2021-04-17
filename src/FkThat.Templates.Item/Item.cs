using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#if isxunit
using FakeItEasy;
using FluentAssertions;
using Xunit;
#endif

namespace @namespace
{
#if (isclass || isxunit)
    public class Item
    {
    }
#elif isinterface
    public interface Item
    {
    }
#endif
}
