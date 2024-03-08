using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace ControlGallery.Views.XAML
{
    public partial class GraphicsViewDemoPage : ContentPage
    {
	    private readonly IDispatcherTimer m_timer;

	    public GraphicsViewDemoPage()
        {
	        InitializeComponent();

	        SizeChanged += OnSizeChanged;
	        m_timer = Dispatcher.CreateTimer();
	        m_timer.Interval = TimeSpan.FromSeconds(0.1);
	        m_timer.Tick += OnTick;
			m_timer.Start();
        }

	    private void OnTick(object sender, EventArgs args)
	    {
		    GraphicsView.Invalidate();
	    }

	    protected virtual void OnSizeChanged(object? sender, EventArgs args)
	    {
		    GraphicsView.Invalidate();
	    }
	}
}
