var data = new Data
{
    RawData = {
        [^1] = 0x05,
        [^2] = 0x04,
        [^3] = 0x03,
        [^4] = 0x02,
        [^5] = 0x01
    }
};

foreach(var @byte in data.RawData)
{
    Console.WriteLine($"0x{@byte:X2}");
}