<div id="edit-this-article-source">
    {{ edit_source | replace_local_to_server}}
</div>

# Legends

A legend is a visual element that displays a list with the name, stroke and fills of the series in a chart:

![legends](https://raw.githubusercontent.com/beto-rodriguez/LiveCharts2/master/docs/_assets/legend.png)

You can place a legend at `Top`, `Bottom`, `Left`, `Right` or `Hidden` positions, notice the `Hidden` position will 
disable legends in a chart, default value is `Hidden`.

{{~ if xaml ~}}
<pre><code>&lt;lvc:CartesianChart
    Series="{Binding Series}"
    LegendPosition="Top">&lt;!-- mark -->
&lt;/lvc:CartesianChart>
&lt;lvc:CartesianChart
    Series="{Binding Series}"
    LegendPosition="Bottom">&lt;!-- mark -->
&lt;/lvc:CartesianChart>
&lt;lvc:CartesianChart
    Series="{Binding Series}"
    LegendPosition="Left">&lt;!-- mark -->
&lt;/lvc:CartesianChart>
&lt;lvc:CartesianChart
    Series="{Binding Series}"
    LegendPosition="Right">&lt;!-- mark -->
&lt;/lvc:CartesianChart>
&lt;lvc:CartesianChart
    Series="{Binding Series}"
    LegendPosition="Hidden">&lt;!-- mark -->
&lt;/lvc:CartesianChart></code></pre>
{{~ end ~}}

{{~ if blazor ~}}
<pre><code>&lt;CartesianChart
    Series="series"
    LegendPosition="LiveChartsCore.Measure.LegendPosition.Top">&lt;!-- mark -->
&lt;/CartesianChart>
&lt;CartesianChart
    Series="series"
    LegendPosition="LiveChartsCore.Measure.LegendPosition.Bottom">&lt;!-- mark -->
&lt;/CartesianChart>
&lt;CartesianChart
    Series="series"
    LegendPosition="LiveChartsCore.Measure.LegendPosition.Left">&lt;!-- mark -->
&lt;/CartesianChart>
&lt;CartesianChart
    Series="series"
    LegendPosition="LiveChartsCore.Measure.LegendPosition.Right">&lt;!-- mark -->
&lt;/CartesianChart>
&lt;CartesianChart
    Series="series"
    LegendPosition="LiveChartsCore.Measure.LegendPosition.Hidden">&lt;!-- mark -->
&lt;/CartesianChart></code></pre>
{{~ end ~}}

{{~ if winforms ~}}
<pre><code>cartesianChart1.TooltipPosition = LiveChartsCore.Measure.LegendPosition.Bottom; // mark
// or use Top, Left, Right or Hidden
</code></pre>
{{~ end ~}}

## Styling legends

{{~ if xaml ~}}
A chart exposes many properties to quickly style a legend:

<pre><code>&lt;lvc:CartesianChart
    Series="{Binding Series}"
    LegendPosition="Left"
    LegendFontFamily="Courier New"
    LegendFontSize="25"
    LegendTextBrush="#f2f4c3"
    LegendBackground="#480032">
&lt;/lvc:CartesianChart>
</code></pre>
{{~ end ~}}

{{~ if winforms ~}}
A chart exposes many properties to quickly style a legend:

<pre><code>cartesianChart1.LegendPosition = LiveChartsCore.Measure.LegendPosition.Left;
cartesianChart1.LegendFont = new System.Drawing.Font("Courier New", 25);
cartesianChart1.LegendTextColor = System.Drawing.Color.FromArgb(255, 50, 50, 50);
cartesianChart1.LegendBackColor = System.Drawing.Color.FromArgb(255, 250, 250, 250);</code></pre>
{{~ end ~}}

{{~ if blazor ~}}
You can use css to override the style of the tooltip.

<pre><code>&lt;style>
    /*
        You can also use css to override the styles.
    */

    .lvc-legend {
        background-color: #fafafa !important;
    }

    .lvc-legend-item {
        font-family: SFMono-Regular,Menlo,Monaco,Consolas !important;
        color: #808080 !important;
    }
&lt;/style></code></pre>
{{~ end ~}}

The code above would result in the following legend:

![custom](https://raw.githubusercontent.com/beto-rodriguez/LiveCharts2/master/docs/_assets/legend-custom-style.png)

## Custom template

{{~ if xaml || blazor ~}}
If you need to customize more, you can also use the create your own template:
{{~ end ~}}

{{~ if avalonia ~}}
<pre><code>&lt;lvc:CartesianChart Series="{Binding Series}" LegendPosition="Right">
    &lt;lvc:CartesianChart.LegendTemplate>
    &lt;DataTemplate>
        &lt;ItemsControl Items="{Binding Series, RelativeSource={RelativeSource AncestorType=lvc:DefaultLegend}}">
        &lt;ItemsControl.ItemsPanel>
            &lt;ItemsPanelTemplate>
            &lt;StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Orientation="Vertical" />
            &lt;/ItemsPanelTemplate>
        &lt;/ItemsControl.ItemsPanel>
        &lt;ItemsControl.ItemTemplate>
            &lt;DataTemplate>
            &lt;Border Padding="7 5" Background="#F5F5DC">
                &lt;StackPanel Orientation="Horizontal">
                &lt;TextBlock
                    Text="{Binding Name}"
                    VerticalAlignment="Center"/>
                &lt;lvc:MotionCanvas
                    Margin="8 0 0 0"
                    PaintTasks="{Binding CanvasSchedule.PaintSchedules}"
                    Width="{Binding CanvasSchedule.Width}"
                    Height="{Binding CanvasSchedule.Height}"
                    VerticalAlignment="Center"/>
                &lt;/StackPanel>
            &lt;/Border>
            &lt;/DataTemplate>
        &lt;/ItemsControl.ItemTemplate>
        &lt;/ItemsControl>
    &lt;/DataTemplate>
    &lt;/lvc:CartesianChart.LegendTemplate>
&lt;/lvc:CartesianChart></code></pre>
{{~ end ~}}

{{~ if blazor ~}}
<pre><code>@page "/General/TemplatedLegends"
@using LiveChartsCore.SkiaSharpView.Blazor
@using ViewModelsSamples.General.TemplatedLegends

&lt;CartesianChart
	Series="ViewModel.Series"
	LegendPosition="LiveChartsCore.Measure.LegendPosition.Right">

	&lt;!--
		Use LegendTemplate property to pass your own template.

		GetSeriesMiniatureStyle():
		returns a css style that sets the width and height css properties
		based on the series properties.

		GetSeriesAsMiniaturePaints():
		returns the series as miniature shapes for the MotionCanvas class.
	-->

	&lt;LegendTemplate>
		&lt;h5>This is a custom legend&lt;/h5>

		@foreach (var series in @context)
		{
			&lt;div class="d-flex">
				&lt;div>
					@series.Name
				&lt;/div>

				&lt;div class="lvc-miniature" style="@LiveChartsBlazor.GetSeriesMiniatureStyle(series)">
					&lt;MotionCanvas PaintTasks="@LiveChartsBlazor.GetSeriesAsMiniaturePaints(series)" />
				&lt;/div>
			&lt;/div>
		}
	&lt;/LegendTemplate>

&lt;/CartesianChart></code></pre>
{{~ end ~}}

{{~ if uwp ~}}
missing sample...
{{~ end ~}}

{{~ if winforms ~}}

You can create your own legend control, the key is that your control must implement `IChartLegend<SkiaSharpDrawingContext>` and then
you have to create a new instance of that control when your chart initializes.

Add a new `UserControl` to your app named `CustomLegend`, then change the code as follows:

<pre><code>using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsSample.General.TemplatedLegends
{
    public partial class CustomLegend : UserControl, IChartLegend&lt;SkiaSharpDrawingContext>
    {
        public CustomLegend()
        {
            InitializeComponent();
        }

        public LegendOrientation Orientation { get; set; }

        public void Draw(Chart&lt;SkiaSharpDrawingContext> chart)
        {
            var wfChart = (Chart)chart.View;

            var series = chart.ChartSeries;
            var legendOrientation = chart.LegendOrientation;

            Visible = true;
            if (legendOrientation == LegendOrientation.Auto) Orientation = LegendOrientation.Vertical;
            Dock = DockStyle.Right;

            DrawAndMesure(series, wfChart);

            BackColor = wfChart.LegendBackColor;
        }

        private void DrawAndMesure(IEnumerable<IChartSeries&lt;SkiaSharpDrawingContext>> series, Chart chart)
        {
            SuspendLayout();
            Controls.Clear();

            var h = 0f;
            var w = 0f;

            var parent = new Panel();
            parent.BackColor = Color.FromArgb(255, 245, 245, 220);
            Controls.Add(parent);
            using var g = CreateGraphics();
            foreach (var s in series)
            {
                var size = g.MeasureString(s.Name, chart.LegendFont);

                var p = new Panel();
                p.Location = new Point(0, (int)h);
                parent.Controls.Add(p);

                p.Controls.Add(new MotionCanvas
                {
                    Location = new Point(6, 0),
                    PaintTasks = s.CanvasSchedule.PaintSchedules,
                    Width = (int)s.CanvasSchedule.Width,
                    Height = (int)s.CanvasSchedule.Height
                });
                p.Controls.Add(new Label
                {
                    Text = s.Name,
                    ForeColor = Color.Black,
                    Font = chart.LegendFont,
                    Location = new Point(6 + (int)s.CanvasSchedule.Width + 6, 0)
                });

                var thisW = size.Width + 36 + (int)s.CanvasSchedule.Width;
                p.Width = (int)thisW + 6;
                p.Height = (int)size.Height + 6;
                h += size.Height + 6;
                w = thisW > w ? thisW : w;
            }
            h += 6;
            parent.Height = (int)h;

            Width = (int)w;
            parent.Location = new Point(0, (int)(Height / 2 - h / 2));

            ResumeLayout();
        }
    }
}</code></pre>

Your legend is ready to be used, now when you create a chart, we have to pass a new instance of the legend we just created.

<pre><code>var cartesianChart = new CartesianChart(legend: new CustomLegend())
{
    Series = viewModel.Series
};</code></pre>
{{~ end ~}}

{{~ if winui ~}}
missing sample...
{{~ end ~}}

{{~ if wpf ~}}
<pre><code>&lt;lvc:CartesianChart Grid.Row="0" Series="{Binding Series}" LegendPosition="Right" >
    &lt;lvc:CartesianChart.LegendTemplate>
        &lt;DataTemplate>
            &lt;ItemsControl ItemsSource="{Binding Series, RelativeSource={RelativeSource AncestorType=lvc:DefaultLegend}}">
                &lt;ItemsControl.ItemsPanel>
                    &lt;ItemsPanelTemplate>
                        &lt;WrapPanel HorizontalAlignment="Center" VerticalAlignment="Center" 
                            Orientation="{Binding Orientation, RelativeSource={RelativeSource AncestorType=lvc:DefaultLegend}}" />
                    &lt;/ItemsPanelTemplate>
                &lt;/ItemsControl.ItemsPanel>
                &lt;ItemsControl.ItemTemplate>
                    &lt;DataTemplate>
                        &lt;Border Padding="15 4" Background="#F5F5DC">
                            &lt;StackPanel Orientation="Horizontal">
                                &lt;TextBlock
                                    Text="{Binding Name}"
                                    VerticalAlignment="Center"/>
                                &lt;lvc:MotionCanvas
                                    Margin="8 0 0 0"
                                    PaintTasks="{Binding CanvasSchedule.PaintSchedules}"
                                    Width="{Binding CanvasSchedule.Width}"
                                    Height="{Binding CanvasSchedule.Height}"
                                    VerticalAlignment="Center"/>
                            &lt;/StackPanel>
                        &lt;/Border>
                    &lt;/DataTemplate>
                &lt;/ItemsControl.ItemTemplate>
            &lt;/ItemsControl>
        &lt;/DataTemplate>
    &lt;/lvc:CartesianChart.LegendTemplate>
&lt;/lvc:CartesianChart></code></pre>
{{~ end ~}}

{{~ if xamarin ~}}
<pre><code>&lt;lvc:CartesianChart Grid.Row="0" Series="{Binding Series}" LegendPosition="Bottom">
    &lt;lvc:CartesianChart.LegendTemplate>
        &lt;DataTemplate>
            &lt;Frame Background="#F5F5DC" CornerRadius="4" Padding="6">
                &lt;StackLayout 
                        BindableLayout.ItemsSource="{Binding Series, Source={RelativeSource AncestorType={x:Type lvc:LegendBindingContext}}}"
                        Orientation="{Binding Orientation, Source={RelativeSource AncestorType={x:Type lvc:LegendBindingContext}}}"
                        VerticalOptions="Center">
                    &lt;BindableLayout.ItemTemplate>
                        &lt;DataTemplate>
                            &lt;StackLayout Orientation="Horizontal" VerticalOptions="Center">
                                &lt;Label
                                    Text="{Binding Name}" />
                                &lt;lvc:MotionCanvas 
                                    VerticalOptions="Center"
                                    Margin="5, 0, 0, 0"
                                    WidthRequest="{Binding Source={RelativeSource AncestorType={x:Type core:ISeries}}, Converter={StaticResource wConverter}}"
                                    HeightRequest="{Binding Source={RelativeSource AncestorType={x:Type core:ISeries}}, Converter={StaticResource hConverter}}"
                                    PaintTasks="{Binding Source={RelativeSource AncestorType={x:Type core:ISeries}}, Converter={StaticResource paintTaskConverter}}"/>
                            &lt;/StackLayout>
                        &lt;/DataTemplate>
                    &lt;/BindableLayout.ItemTemplate>
                &lt;/StackLayout>
            &lt;/Frame>
        &lt;/DataTemplate>
    &lt;/lvc:CartesianChart.LegendTemplate>
&lt;/lvc:CartesianChart></code></pre>
{{~ end ~}}


![custom tooltip](https://raw.githubusercontent.com/beto-rodriguez/LiveCharts2/master/docs/_assets/legend-custom-template.png)