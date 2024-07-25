using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
            Load = SwallowLoad.None;// Initialize with no load
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            if (Type == SwallowType.African && Load == SwallowLoad.None)
            {
                return 22;
            }
            else if (Type == SwallowType.African && Load == SwallowLoad.Coconut)
            {
                return 18;
            }
            else if (Type == SwallowType.European && Load == SwallowLoad.None)
            {
                return 20;
            }
            else if (Type == SwallowType.European && Load == SwallowLoad.Coconut)
            {
                return 16;
            }
            else
            {
                throw new InvalidOperationException("Unknown combination of SwallowType and SwallowLoad");
            }
        }
    }
}
