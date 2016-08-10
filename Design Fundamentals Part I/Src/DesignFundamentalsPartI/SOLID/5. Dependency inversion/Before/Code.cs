using SOLID._5._Dependency_inversion.Before.LowLevel;

namespace SOLID._5._Dependency_inversion.Before
{
    namespace HighLevel
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

    namespace LowLevel
    {
        class LowLevelClass
        {
            public object Get(int id) { return null; }
            public void Save(object value) { }
        }
    }
}
