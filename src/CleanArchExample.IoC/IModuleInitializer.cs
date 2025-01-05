using Microsoft.AspNetCore.Builder;

namespace CleanArchExample.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
