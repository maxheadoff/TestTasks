using System;
namespace MuseumCrowd
{
    /// <summary>
    /// Представляет метод, который возвращает период времени, когда было самое большое количество посетителей
    /// </summary>
    public interface ICrowd
    {
        TimePair GetPeriod();
    }
    /// <summary>
    /// IN - посетитель вошел, OUT - вышел
    /// </summary>
    public enum Direction { IN = 1, OUT = -1 };
}
