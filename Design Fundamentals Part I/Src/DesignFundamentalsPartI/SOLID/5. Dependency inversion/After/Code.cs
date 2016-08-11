namespace SOLID._5._Dependency_inversion.After
{
    namespace HighLevel.Important
    {
        class HighLevelClass
        {
            private readonly ILowLevel lowLevel;
            public HighLevelClass(ILowLevel lowLevel)
            {
                this.lowLevel = lowLevel;
            }

            void Execute()
            {
                var param = lowLevel.Get(1);
                //CODE
                lowLevel.Save(param);
            }
        }
                
        public interface ILowLevel
        {
            object Get(int id);
            void Save(object value);
        }
    }

    namespace LowLevel.Plugin
    {
        using SOLID._5._Dependency_inversion.After.HighLevel.Important;

        class LowLevelClass : ILowLevel
        {
            public object Get(int id) { return null; }
            public void Save(object value) { }
        }
    }
}
