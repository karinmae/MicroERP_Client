﻿// #define ENABLE_ICON_SUPPORT

namespace MicroErp.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    using MicroErp.ViewModels;

    public class CommandButton
        : Button
    {
        public CommandButton()
        {
            var bCmd = new Binding("CommandViewModel");
            bCmd.RelativeSource = RelativeSource.Self;
            this.SetBinding(CommandProperty, bCmd);

            var bLabel = new Binding("CommandViewModel.Label");
            bLabel.RelativeSource = RelativeSource.Self;
            this.SetBinding(ContentProperty, bLabel);

            var bTooltip = new Binding("CommandViewModel.ToolTip");
            bTooltip.RelativeSource = RelativeSource.Self;
            this.SetBinding(ToolTipProperty, bTooltip);

#if ENABLE_ICON_SUPPORT
            var bImage = new Binding("CommandViewModel.Icon");
            bImage.RelativeSource = RelativeSource.Self;
            bImage.Converter = (IValueConverter)Application.Current.Resources["IconConverter"];
            this.SetBinding(ImageProperty, bImage);
#endif
            this.SetValue(ToolTipService.ShowOnDisabledProperty, true);

            this.Loaded += new RoutedEventHandler(CommandButton_Loaded);
        }

        void CommandButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                this.Content = "Command Button";
            }
            this.CommandTarget = this;
        }

        public ICommandViewModel CommandViewModel
        {
            get { return (ICommandViewModel)GetValue(CommandViewModelProperty); }
            set { SetValue(CommandViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandViewModelProperty =
            DependencyProperty.Register("CommandViewModel", typeof(ICommandViewModel), typeof(CommandButton));

#if ENABLE_ICON_SUPPORT
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(CommandButton));
#endif
    }
}
