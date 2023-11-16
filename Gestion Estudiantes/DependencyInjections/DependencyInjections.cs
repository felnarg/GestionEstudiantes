namespace Gestion_Estudiantes.DependencyInjections
{
    public static class DependencyInjections
    {
        public static void Inject(this WebApplicationBuilder builder)
        {
            DataBaseInjections.InjectDb(builder);
            ServiceInjections.InjectServices(builder);
        }
    }
}
