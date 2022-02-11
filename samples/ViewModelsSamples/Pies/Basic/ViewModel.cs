using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.Generic;

namespace ViewModelsSamples.Pies.Basic
{
    public class ViewModel
    {
        public IEnumerable<ISeries> Series { get; set; } = new List<ISeries>
        {

            new PieSeries<double> { Values = new List<double> { 8,9 } },
            new PieSeries<double> { Values = new List<double> { 9,13 } },
            new PieSeries<double> { Values = new List<double> { 12,9 } },
            new PieSeries<double> { Values = new List<double> { 1,3 }, Stroke = new SolidColorPaint(SKColors.Black,3) }
        };

    }
}
