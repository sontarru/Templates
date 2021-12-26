using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FkThat.Templates.Cli
{
    public interface IApplication
    {
        Task RunAsync(IEnumerable<string> args, CancellationToken cancellationToken);
    }
}
