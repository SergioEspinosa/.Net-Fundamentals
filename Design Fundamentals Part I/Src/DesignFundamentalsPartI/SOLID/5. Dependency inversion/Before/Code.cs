using SOLID._5._Dependency_inversion.Before.LowLevel.Plugin;

namespace SOLID._5._Dependency_inversion.Before
{
    namespace HighLevel.Important
    {
        class HighLevelClass
        {
            void Execute()
            {
                var lowLevel = new LowLevelClass();
                var param = lowLevel.Get(1);

                //CODE

                lowLevel.Save(param);
            }
        }
    }

    namespace LowLevel.Plugin
    {
        class LowLevelClass
        {
            public object Get(int id) { return null; }
            public void Save(object value) { }
        }
    }
}
