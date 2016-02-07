namespace Codheadz.PiLITEr
{
    internal interface IGpioControllerWrapper
    {
        IGpioPinWrapper OpenPin(int i);
    }
}