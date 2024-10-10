namespace BackendBG.Scrutor
{
    public static class Services
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly = typeof(IServices<>).Assembly;
            services.Scan((x) => x.FromAssemblies(assembly).AddClasses((c) => c.AssignableTo(typeof(IServices<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            return services;
        }

    }
}
