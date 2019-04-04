using System;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

namespace _961CSharpApi
{
    public delegate void CallBack(Thread currentThread);

    class VBAPI
    {
        public abstract class ButtonBase : Control
        {
            public new event ClickEventHandler Click
            {
                add
                {
                    var clickEventHandler = ClickEvent;
                    ClickEventHandler clickEventHandler2;
                    do
                    {
                        clickEventHandler2 = clickEventHandler;
                        var value2 = (ClickEventHandler)Delegate.Combine(clickEventHandler2, value);
                        clickEventHandler = Interlocked.CompareExchange(ref ClickEvent, value2, clickEventHandler2);
                    }
                    while (clickEventHandler != clickEventHandler2);
                }

                remove
                {
                    var clickEventHandler = ClickEvent;
                    ClickEventHandler clickEventHandler2;
                    do
                    {
                        clickEventHandler2 = clickEventHandler;
                        var value2 = (ClickEventHandler)Delegate.Remove(clickEventHandler2, value);
                        clickEventHandler = Interlocked.CompareExchange(ref ClickEvent, value2, clickEventHandler2);
                    }
                    while (clickEventHandler != clickEventHandler2);
                }
            }

            public new bool Enabled
            {
                get
                {
                    return EnabledCalc;
                }
                set
                {
                    IsEnabled = value;
                    var enabled = Enabled;
                    Cursor = enabled ? Cursors.Hand : Cursors.Default;
                    Invalidate();
                }
            }

            [DisplayName("Enabled")]
            public bool EnabledCalc
            {
                get
                {
                    return IsEnabled;
                }
                set
                {
                    Enabled = value;
                    Invalidate();
                }
            }

            public ButtonBase()
            {
                DoubleBuffered = true;
                Enabled = true;
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                var enabled = Enabled;
                if (!enabled) return;
                var clickEvent = ClickEvent;
                clickEvent?.Invoke(this, e);
            }

            private ClickEventHandler ClickEvent;

            private bool IsEnabled;

            public delegate void ClickEventHandler(object sender, EventArgs e);
        }

        public abstract class CheckControl : Control
        {
            public event CheckedChangedEventHandler CheckedChanged
            {
                add
                {
                    var checkedChangedEventHandler = CheckedChangedEvent;
                    CheckedChangedEventHandler checkedChangedEventHandler2;
                    do
                    {
                        checkedChangedEventHandler2 = checkedChangedEventHandler;
                        var value2 = (CheckedChangedEventHandler)Delegate.Combine(checkedChangedEventHandler2, value);
                        checkedChangedEventHandler = Interlocked.CompareExchange(ref CheckedChangedEvent, value2, checkedChangedEventHandler2);
                    }
                    while (checkedChangedEventHandler != checkedChangedEventHandler2);
                }

                remove
                {
                    var checkedChangedEventHandler = CheckedChangedEvent;
                    CheckedChangedEventHandler checkedChangedEventHandler2;
                    do
                    {
                        checkedChangedEventHandler2 = checkedChangedEventHandler;
                        var value2 = (CheckedChangedEventHandler)Delegate.Remove(checkedChangedEventHandler2, value);
                        checkedChangedEventHandler = Interlocked.CompareExchange(ref CheckedChangedEvent, value2, checkedChangedEventHandler2);
                    }
                    while (checkedChangedEventHandler != checkedChangedEventHandler2);
                }
            }

            public new bool Enabled
            {
                get
                {
                    return EnabledCalc;
                }
                set
                {
                    IsEnabled = value;
                    var enabled = Enabled;
                    Cursor = enabled ? Cursors.Hand : Cursors.Default;
                    Invalidate();
                }
            }

            [DisplayName("Enabled")]
            public bool EnabledCalc
            {
                get
                {
                    return IsEnabled;
                }
                set
                {
                    Enabled = value;
                    Invalidate();
                }
            }

            public bool Checked
            {
                get
                {
                    return IsChecked;
                }
                set
                {
                    IsChecked = value;
                    Invalidate();
                }
            }

            public CheckControl()
            {
                Enabled = true;
                DoubleBuffered = true;
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                var enabled = Enabled;
                if (!enabled) return;
                Checked = !Checked;
                var checkedChangedEvent = CheckedChangedEvent;
                checkedChangedEvent?.Invoke(this, e);
            }

            private CheckedChangedEventHandler CheckedChangedEvent;

            private bool IsEnabled;

            private bool IsChecked;

            public delegate void CheckedChangedEventHandler(object sender, EventArgs e);
        }

        public abstract class LeftTabControl : TabControl
        {
            public bool Hovering
            {
                get
                {
                    return OverIndex != -1;
                }
            }

            public int OverIndex
            {
                get
                {
                    return _OverIndex;
                }
                set
                {
                    _OverIndex = value;
                    bool flag = _OverIndex != -1;
                    if (flag)
                    {
                        OverRect = new Rectangle(GetTabRect(OverIndex).X, GetTabRect(OverIndex).Y, GetTabRect(OverIndex).Width, GetTabRect(OverIndex).Height);
                    }
                    Invalidate();
                }
            }

            protected override void OnCreateControl()
            {
                base.OnCreateControl();
                SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnControlAdded(ControlEventArgs e)
            {
                base.OnControlAdded(e);
                e.Control.BackColor = Color.White;
                e.Control.ForeColor = Helpers2.ColorFromHex961("#72778D");
                e.Control.Font = new Font("Segoe UI", 9f);
            }

            public LeftTabControl()
            {
                ItemWidth = 180;
                _OverIndex = -1;
                DoubleBuffered = true;
                Alignment = TabAlignment.Left;
                ItemSize = new Size(40, ItemWidth);
                SizeMode = TabSizeMode.Fixed;
                Font = new Font("Segoe UI", 9f);
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                checked
                {
                    int num = TabPages.Count - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        bool flag = GetTabRect(i).Contains(e.Location) & SelectedIndex != i;
                        if (flag)
                        {
                            OverIndex = i;
                            break;
                        }
                        OverIndex = -1;
                    }
                    base.OnMouseMove(e);
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                OverIndex = -1;
            }

            public Rectangle BaseRect;

            public Rectangle OverRect;

            public int ItemWidth;

            private int _OverIndex;
        }

        public abstract class RadioButtonBase : Control
        {
            public event CheckedChangedEventHandler CheckedChanged
            {
                add
                {
                    var checkedChangedEventHandler = CheckedChangedEvent;
                    CheckedChangedEventHandler checkedChangedEventHandler2;
                    do
                    {
                        checkedChangedEventHandler2 = checkedChangedEventHandler;
                        var value2 = (CheckedChangedEventHandler)Delegate.Combine(checkedChangedEventHandler2, value);
                        checkedChangedEventHandler = Interlocked.CompareExchange(ref CheckedChangedEvent, value2, checkedChangedEventHandler2);
                    }
                    while (checkedChangedEventHandler != checkedChangedEventHandler2);
                }

                remove
                {
                    var checkedChangedEventHandler = CheckedChangedEvent;
                    CheckedChangedEventHandler checkedChangedEventHandler2;
                    do
                    {
                        checkedChangedEventHandler2 = checkedChangedEventHandler;
                        var value2 = (CheckedChangedEventHandler)Delegate.Remove(checkedChangedEventHandler2, value);
                        checkedChangedEventHandler = Interlocked.CompareExchange(ref CheckedChangedEvent, value2, checkedChangedEventHandler2);
                    }
                    while (checkedChangedEventHandler != checkedChangedEventHandler2);
                }
            }

            public new bool Enabled
            {
                get
                {
                    return EnabledCalc;
                }
                set
                {
                    IsEnabled = value;
                    var enabled = Enabled;
                    Cursor = enabled ? Cursors.Hand : Cursors.Default;
                    Invalidate();
                }
            }

            [DisplayName("Enabled")]
            public bool EnabledCalc
            {
                get
                {
                    return IsEnabled;
                }
                set
                {
                    Enabled = value;
                    Invalidate();
                }
            }

            public bool Checked
            {
                get
                {
                    return IsChecked;
                }
                set
                {
                    IsChecked = value;
                    Invalidate();
                }
            }

            public RadioButtonBase()
            {
                Enabled = true;
                DoubleBuffered = true;
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                var enabled = Enabled;
                if (!enabled) return;
                var flag = !Checked;
                if (flag)
                {
                    foreach (var obj in Parent.Controls)
                    {
                        var control = (Control)obj;
                        var flag2 = control is RadioButtonBase;
                        if (flag2)
                        {
                            ((RadioButtonBase)control).Checked = false;
                        }
                    }
                }
                Checked = true;
                var checkedChangedEvent = CheckedChangedEvent;
                checkedChangedEvent?.Invoke(this, e);
            }

            private CheckedChangedEventHandler CheckedChangedEvent;

            private bool IsEnabled;

            private bool IsChecked;

            public delegate void CheckedChangedEventHandler(object sender, EventArgs e);
        }

        public abstract class TopTabControl : TabControl
        {
            public bool Hovering
            {
                get
                {
                    return OverIndex != -1;
                }
            }

            public int OverIndex
            {
                get
                {
                    return _OverIndex;
                }
                set
                {
                    _OverIndex = value;
                    var flag = _OverIndex != -1;
                    if (flag)
                    {
                        OverRect = new Rectangle(GetTabRect(OverIndex).X, GetTabRect(OverIndex).Y, GetTabRect(OverIndex).Width, GetTabRect(OverIndex).Height);
                    }
                    Invalidate();
                }
            }

            protected override void OnCreateControl()
            {
                base.OnCreateControl();
                SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnControlAdded(ControlEventArgs e)
            {
                base.OnControlAdded(e);
                e.Control.BackColor = Color.White;
                e.Control.ForeColor = Helpers2.ColorFromHex961("#72778D");
                e.Control.Font = new Font("Segoe UI", 9f);
            }

            public TopTabControl()
            {
                ItemWidth = 20;
                _OverIndex = -1;
                DoubleBuffered = true;
                Alignment = TabAlignment.Top;
                ItemSize = new Size(15, 15);
                SizeMode = TabSizeMode.Fixed;
                Font = new Font("Segoe UI", 9f);
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                checked
                {
                    var num = TabPages.Count - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        var flag = GetTabRect(i).Contains(e.Location) & SelectedIndex != i;
                        if (flag)
                        {
                            OverIndex = i;
                            break;
                        }
                        OverIndex = -1;
                    }
                    base.OnMouseMove(e);
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                OverIndex = -1;
            }

            public Rectangle BaseRect;

            public Rectangle OverRect;

            public int ItemWidth;

            private int _OverIndex;
        }

        public class StrafeButton : ButtonBase
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(Parent.BackColor);
                var enabled = Enabled;
                if (enabled)
                {
                }
                base.OnPaint(e);
            }

            private Graphics G;
        }

        public class StrafeCheckBox : CheckControl
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                var enabled = Enabled;
                if (enabled)
                {
                    using (var pen = new Pen(Helpers2.ColorFromHex961("#C8C8C8")))
                    {
                        using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#72778D")))
                        {
                            using (var font = new Font("Segoe UI", 9f))
                            {
                                G.DrawRectangle(pen, new Rectangle(0, 0, 16, 16));
                                G.DrawString(Text, font, solidBrush, new Point(22, 0));
                            }
                        }
                    }
                    var @checked = Checked;
                    if (@checked)
                    {
                        using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961("#40B1D0")))
                        {
                            using (var pen2 = new Pen(Helpers2.ColorFromHex961("#3CA3C3")))
                            {
                                G.FillRectangle(solidBrush2, new Rectangle(3, 3, 10, 10));
                                G.DrawRectangle(pen2, new Rectangle(3, 3, 10, 10));
                            }
                        }
                    }
                }
                else
                {
                    using (var pen3 = new Pen(Helpers2.ColorFromHex961("#E8E8E8")))
                    {
                        using (var solidBrush3 = new SolidBrush(Helpers2.ColorFromHex961("#B8BDC9")))
                        {
                            using (var font2 = new Font("Segoe UI", 9f))
                            {
                                G.DrawRectangle(pen3, new Rectangle(0, 0, 16, 16));
                                G.DrawString(Text, font2, solidBrush3, new Point(22, 0));
                            }
                        }
                    }
                    var checked2 = Checked;
                    if (checked2)
                    {
                        using (var solidBrush4 = new SolidBrush(Helpers2.ColorFromHex961("#A0C4CE")))
                        {
                            using (var pen4 = new Pen(Helpers2.ColorFromHex961("#9FC1CB")))
                            {
                                G.FillRectangle(solidBrush4, new Rectangle(3, 3, 10, 10));
                                G.DrawRectangle(pen4, new Rectangle(3, 3, 10, 10));
                            }
                        }
                    }
                }
                base.OnPaint(e);
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Size = new Size(Width, 17);
            }

            private Graphics G;
        }

        public class StrafeCircular : Control
        {
            public bool ShowMax { get; set; }

            public float Progress
            {
                get
                {
                    return _Progress;
                }
                set
                {
                    var num = value;
                    var flag = num > Max;
                    if (flag)
                    {
                        value = Max;
                        Invalidate();
                    }
                    else
                    {
                        flag = (num < Min);
                        if (flag)
                        {
                            value = Min;
                            Invalidate();
                        }
                    }
                    _Progress = value;
                    Invalidate();
                }
            }

            public float Max
            {
                get
                {
                    return _Max;
                }
                set
                {
                    var flag = value < _Progress;
                    if (flag)
                    {
                        _Progress = value;
                    }
                    _Max = value;
                    Invalidate();
                }
            }

            public float Min
            {
                get
                {
                    return _Min;
                }
                set
                {
                    var flag = value > _Progress;
                    if (flag)
                    {
                        _Progress = value;
                    }
                    _Min = value;
                    Invalidate();
                }
            }

            public StrafeCircular()
            {
                _Max = 100f;
                _Min = 0f;
                DoubleBuffered = true;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                ProgressAngle = 360f / Max * Progress;
                RemainderAngle = 360f - ProgressAngle;
                checked
                {
                    using (var pen = new Pen(Helpers2.ColorFromHex961("#40B1D0"), 4f))
                    {
                        using (var pen2 = new Pen(Helpers2.ColorFromHex961("#E8E8E8"), 4f))
                        {
                            G.DrawArc(pen, new Rectangle(2, 2, Width - 5, Height - 5), -90f, ProgressAngle);
                            G.DrawArc(pen2, new Rectangle(2, 2, Width - 5, Height - 5), ProgressAngle - 90f, RemainderAngle);
                        }
                    }
                    using (var font = new Font("Segoe UI", 9f, FontStyle.Bold))
                    {
                        using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#4E5260")))
                        {
                            Helpers2.CenterString961(G, Conversions.ToString(Progress), font, solidBrush.Color, new Rectangle(1, 1, Width, Height + 1));
                        }
                    }
                    var showMax = ShowMax;
                    if (showMax)
                    {
                        using (var font2 = new Font("Segoe UI", 7f, FontStyle.Bold))
                        {
                            using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961("#B8BDC9")))
                            {
                                Helpers2.CenterString961(G, Conversions.ToString(Max), font2, solidBrush2.Color, new Rectangle(0, 11, Width, Height + 1));
                            }
                        }
                    }
                    base.OnPaint(e);
                }
            }

            private Graphics G;

            private float ProgressAngle;

            private float RemainderAngle;

            private float _Progress;

            private float _Max;

            private float _Min;
        }

        public class StrafeHeader : Control
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(Parent.BackColor);
                using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#4E5260")))
                {
                    using (var font = new Font("Segoe UI semibold", 15f))
                    {
                        G.DrawString(Text, font, solidBrush, new Point(0, 0));
                    }
                }
                base.OnPaint(e);
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Size = new Size(Width, 32);
            }

            private Graphics G;
        }

        public class StrafeNumericUpDown : Control
        {
            public event ValueChangedEventHandler ValueChanged
            {
                add
                {
                    var valueChangedEventHandler = ValueChangedEvent;
                    ValueChangedEventHandler valueChangedEventHandler2;
                    do
                    {
                        valueChangedEventHandler2 = valueChangedEventHandler;
                        var value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
                        valueChangedEventHandler = Interlocked.CompareExchange(ref ValueChangedEvent, value2, valueChangedEventHandler2);
                    }
                    while (valueChangedEventHandler != valueChangedEventHandler2);
                }

                remove
                {
                    var valueChangedEventHandler = ValueChangedEvent;
                    ValueChangedEventHandler valueChangedEventHandler2;
                    do
                    {
                        valueChangedEventHandler2 = valueChangedEventHandler;
                        var value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
                        valueChangedEventHandler = Interlocked.CompareExchange(ref ValueChangedEvent, value2, valueChangedEventHandler2);
                    }
                    while (valueChangedEventHandler != valueChangedEventHandler2);
                }
            }

            public int UpDownStep
            {
                get;
                set;
            }

            public int Value
            {
                get
                {
                    return _Value;
                }
                set
                {
                    var num = value;
                    var flag = num > Max;
                    if (flag)
                    {
                        value = Max;
                        Invalidate();
                    }
                    else
                    {
                        flag = (num < Min);
                        if (flag)
                        {
                            value = Min;
                            Invalidate();
                        }
                    }
                    _Value = value;
                    Invalidate();
                    var valueChangedEvent = ValueChangedEvent;
                    valueChangedEvent?.Invoke(this, EventArgs.Empty);
                }
            }

            public int Max
            {
                get
                {
                    return _Max;
                }
                set
                {
                    var flag = value < _Value;
                    if (flag)
                    {
                        _Value = value;
                    }
                    _Max = value;
                    Invalidate();
                }
            }

            public int Min
            {
                get
                {
                    return _Min;
                }
                set
                {
                    var flag = value > _Value;
                    if (flag)
                    {
                        _Value = value;
                    }
                    _Min = value;
                    Invalidate();
                }
            }

            public new bool Enabled
            {
                get
                {
                    return EnabledCalc;
                }
                set
                {
                    IsEnabled = value;
                    Invalidate();
                }
            }

            [DisplayName("Enabled")]
            public bool EnabledCalc
            {
                get
                {
                    return IsEnabled;
                }
                set
                {
                    Enabled = value;
                    Invalidate();
                }
            }

            public StrafeNumericUpDown()
            {
                UpDownStep = 1;
                _Max = 100;
                Enabled = true;
                DoubleBuffered = true;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                var enabled = Enabled;
                checked
                {
                    if (enabled)
                    {
                        using (var pen = new Pen(Helpers2.ColorFromHex961("#C8C8C8")))
                        {
                            G.DrawRectangle(pen, Helpers2.FullRectangle961(Size, true));
                            G.DrawRectangle(pen, new Rectangle(Width - 20, 4, 15, 18));
                        }
                        using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#424E5A")))
                        {
                            using (var font = new Font("Segoe UI", 10f))
                            {
                                Helpers2.CenterString961(G, Conversions.ToString(Value), font, solidBrush.Color, new Rectangle(-10, 0, Width, Height));
                            }
                        }
                        using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961("#72778D")))
                        {
                            using (var font2 = new Font("Marlett", 10f))
                            {
                                G.DrawString("t", font2, solidBrush2, new Point(Width - 20, 4));
                                G.DrawString("u", font2, solidBrush2, new Point(Width - 20, 10));
                            }
                        }
                    }
                    else
                    {
                        using (var pen2 = new Pen(Helpers2.ColorFromHex961("#E6E6E6")))
                        {
                            G.DrawRectangle(pen2, Helpers2.FullRectangle961(Size, true));
                            G.DrawRectangle(pen2, new Rectangle(Width - 20, 4, 15, 18));
                        }
                        using (var solidBrush3 = new SolidBrush(Helpers2.ColorFromHex961("#A6B2BE")))
                        {
                            using (var font3 = new Font("Segoe UI", 10f))
                            {
                                Helpers2.CenterString961(G, Conversions.ToString(Value), font3, solidBrush3.Color, new Rectangle(-10, 0, Width, Height));
                            }
                        }
                        using (var solidBrush4 = new SolidBrush(Helpers2.ColorFromHex961("#BAC6D2")))
                        {
                            using (var font4 = new Font("Marlett", 10f))
                            {
                                G.DrawString("t", font4, solidBrush4, new Point(Width - 20, 4));
                                G.DrawString("u", font4, solidBrush4, new Point(Width - 20, 10));
                            }
                        }
                    }
                    base.OnPaint(e);
                }
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                var enabled = Enabled;
                checked
                {
                    if (enabled)
                    {
                        var flag = e.X > Width - 20 & e.Y < 10;
                        if (flag)
                        {
                            Value += UpDownStep;
                        }
                        else
                        {
                            var flag2 = e.X > Width - 20 & e.Y > 10;
                            if (flag2)
                            {
                                Value -= UpDownStep;
                            }
                        }
                    }
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                var enabled = Enabled;
                checked
                {
                    if (enabled)
                    {
                        var flag = e.X > Width - 20 & e.Y < 10;
                        if (flag)
                        {
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            var flag2 = e.X > Width - 20 & e.Y > 10;
                            if (flag2)
                            {
                                Cursor = Cursors.Hand;
                            }
                            else
                            {
                                Cursor = Cursors.Default;
                            }
                        }
                    }
                }
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Size = new Size(Width, 27);
            }

            private ValueChangedEventHandler ValueChangedEvent;

            private Graphics G;

            private bool IsEnabled;

            private int _Value;

            private int _Max;

            private int _Min;

            public delegate void ValueChangedEventHandler(object sender, EventArgs e);
        }

        public class StrafeOnOffBox : CheckControl
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                var enabled = Enabled;
                checked
                {
                    if (enabled)
                    {
                        var flag = !Checked;
                        if (flag)
                        {
                            using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#C8C8C8")))
                            {
                                using (var pen = new Pen(Helpers2.ColorFromHex961("#C3C3C3")))
                                {
                                    using (var pen2 = new Pen(Helpers2.ColorFromHex961("#C3C3C3")))
                                    {
                                        G.FillRectangle(solidBrush, Helpers2.FullRectangle961(Size, true));
                                        G.DrawRectangle(pen, Helpers2.FullRectangle961(Size, true));
                                        G.FillRectangle(Brushes.White, new Rectangle(3, 3, 16, Height - 7));
                                        G.DrawRectangle(pen2, new Rectangle(3, 3, 16, Height - 7));
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961("#40B1D0")))
                            {
                                using (var pen3 = new Pen(Helpers2.ColorFromHex961("#3CA3C3")))
                                {
                                    using (var pen4 = new Pen(Helpers2.ColorFromHex961("#3CA3C3")))
                                    {
                                        G.FillRectangle(solidBrush2, Helpers2.FullRectangle961(Size, true));
                                        G.DrawRectangle(pen3, Helpers2.FullRectangle961(Size, true));
                                        G.FillRectangle(Brushes.White, new Rectangle(Width - 20, 3, 16, Height - 7));
                                        G.DrawRectangle(pen4, new Rectangle(Width - 20, 3, 16, Height - 7));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var flag2 = !Checked;
                        if (flag2)
                        {
                            using (var solidBrush3 = new SolidBrush(Helpers2.ColorFromHex961("#E8E8E8")))
                            {
                                using (var pen5 = new Pen(Helpers2.ColorFromHex961("#DEDEDE")))
                                {
                                    using (var pen6 = new Pen(Helpers2.ColorFromHex961("#E0E0E0")))
                                    {
                                        G.FillRectangle(solidBrush3, Helpers2.FullRectangle961(Size, true));
                                        G.DrawRectangle(pen5, Helpers2.FullRectangle961(Size, true));
                                        G.FillRectangle(Brushes.White, new Rectangle(3, 3, 16, Height - 7));
                                        G.DrawRectangle(pen6, new Rectangle(3, 3, 16, Height - 7));
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (var solidBrush4 = new SolidBrush(Helpers2.ColorFromHex961("#A0C4CE")))
                            {
                                using (var pen7 = new Pen(Helpers2.ColorFromHex961("#9FC1CB")))
                                {
                                    using (var pen8 = new Pen(Helpers2.ColorFromHex961("#9FC1CB")))
                                    {
                                        G.FillRectangle(solidBrush4, Helpers2.FullRectangle961(Size, true));
                                        G.DrawRectangle(pen7, Helpers2.FullRectangle961(Size, true));
                                        G.FillRectangle(Brushes.White, new Rectangle(Width - 20, 3, 16, Height - 7));
                                        G.DrawRectangle(pen8, new Rectangle(Width - 20, 3, 16, Height - 7));
                                    }
                                }
                            }
                        }
                    }
                    base.OnPaint(e);
                }
            }

            private Graphics G;
        }

        public class StrafeProgressBar : Control
        {
            public int Value
            {
                get
                {
                    return _Val;
                }
                set
                {
                    _Val = value;
                    Invalidate();
                }
            }

            public int Minimum
            {
                get
                {
                    return _Min;
                }
                set
                {
                    _Min = value;
                    Invalidate();
                }
            }

            public int Maximum
            {
                get
                {
                    return _Max;
                }
                set
                {
                    _Max = value;
                    Invalidate();
                }
            }

            public StrafeProgressBar()
            {
                _Val = 0;
                _Min = 0;
                _Max = 100;
                DoubleBuffered = true;
                Maximum = 100;
                Minimum = 0;
                Value = 0;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(Parent.BackColor);
                using (var pen = new Pen(Helpers2.ColorFromHex961("#D0D5D9")))
                {
                    G.DrawRectangle(pen, Helpers2.FullRectangle961(Size, true));
                }
                using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#40B1D0")))
                {
                    using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961("#E8E8E8")))
                    {
                        G.FillRectangle(solidBrush2, Helpers2.FullRectangle961(Size, true));
                        G.FillRectangle(solidBrush, checked(new Rectangle(0, 0, (int)Math.Round((double)Value / (double)Maximum * (double)Width - 1.0), Height - 1)));
                    }
                }
                base.OnPaint(e);
            }

            private Graphics G;

            private int _Val;

            private int _Min;

            private int _Max;
        }

        public class StrafeRadioButton : RadioButtonBase
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                var enabled = Enabled;
                if (enabled)
                {
                    using (var pen = new Pen(Helpers2.ColorFromHex961("#C8C8C8")))
                    {
                        using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#72778D")))
                        {
                            using (var font = new Font("Segoe UI", 9f))
                            {
                                G.DrawEllipse(pen, new Rectangle(0, 0, 16, 16));
                                G.DrawString(Text, font, solidBrush, new Point(22, 0));
                            }
                        }
                    }
                    var @checked = Checked;
                    if (@checked)
                    {
                        using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961("#40B1D0")))
                        {
                            using (var pen2 = new Pen(Helpers2.ColorFromHex961("#3CA3C3")))
                            {
                                G.FillEllipse(solidBrush2, new Rectangle(3, 3, 10, 10));
                                G.DrawEllipse(pen2, new Rectangle(3, 3, 10, 10));
                            }
                        }
                    }
                }
                else
                {
                    using (var pen3 = new Pen(Helpers2.ColorFromHex961("#E8E8E8")))
                    {
                        using (var solidBrush3 = new SolidBrush(Helpers2.ColorFromHex961("#B8BDC9")))
                        {
                            using (var font2 = new Font("Segoe UI", 9f))
                            {
                                G.DrawEllipse(pen3, new Rectangle(0, 0, 16, 16));
                                G.DrawString(Text, font2, solidBrush3, new Point(22, 0));
                            }
                        }
                    }
                    var checked2 = Checked;
                    if (checked2)
                    {
                        using (var solidBrush4 = new SolidBrush(Helpers2.ColorFromHex961("#A0C4CE")))
                        {
                            using (var pen4 = new Pen(Helpers2.ColorFromHex961("#9FC1CB")))
                            {
                                G.FillEllipse(solidBrush4, new Rectangle(3, 3, 10, 10));
                                G.DrawEllipse(pen4, new Rectangle(3, 3, 10, 10));
                            }
                        }
                    }
                }
                base.OnPaint(e);
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Size = new Size(Width, 17);
            }

            private Graphics G;
        }

        public class StrafeSelector : TopTabControl
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(Parent.BackColor);
                checked
                {
                    var num = TabPages.Count - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        BaseRect = GetTabRect(i);
                        var flag = SelectedIndex == i;
                        if (flag)
                        {
                            var flag2 = string.IsNullOrEmpty(Conversions.ToString(TabPages[i].Tag));
                            if (flag2)
                            {
                                using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#40B1D0")))
                                {
                                    G.FillEllipse(solidBrush, new Rectangle(BaseRect.X + 5, BaseRect.Y + 5, 9, 9));
                                }
                            }
                            else
                            {
                                var flag3 = TabPages[i].Tag.ToString().Length == 7;
                                if (flag3)
                                {
                                    using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961(Conversions.ToString(TabPages[i].Tag))))
                                    {
                                        G.FillEllipse(solidBrush2, new Rectangle(BaseRect.X + 5, BaseRect.Y + 5, 9, 9));
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (var solidBrush3 = new SolidBrush(Helpers2.ColorFromHex961("#C8C8C8")))
                            {
                                using (var pen = new Pen(Helpers2.ColorFromHex961("#C3C3C3")))
                                {
                                    G.FillEllipse(solidBrush3, new Rectangle(BaseRect.X + 5, BaseRect.Y + 5, 9, 9));
                                    G.DrawEllipse(pen, new Rectangle(BaseRect.X + 5, BaseRect.Y + 5, 9, 9));
                                }
                            }
                        }
                        var hovering = Hovering;
                        Cursor = hovering ? Cursors.Hand : Cursors.Default;
                    }
                    base.OnPaint(e);
                }
            }

            private Graphics G;
        }

        public class StrafeSeparator : Control
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(Parent.BackColor);
                using (var pen = new Pen(Helpers2.ColorFromHex961("#ECEFF3")))
                {
                    G.DrawLine(pen, 0, 0, Width, 0);
                }
                base.OnPaint(e);
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Size = new Size(Width, 6);
            }

            private Graphics G;
        }

        public class StrafeTabControl : LeftTabControl
        {
            public StrafeTabControl()
            {
                B64Arrow = "iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAQAAAAnOwc2AAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAAAmJLR0QA/4ePzL8AAAAHdElNRQffDAEGGjYp6p3OAAAAgklEQVQI122OwQnCQBRE319jmvBgS3rwJFpYKjCxBfsRPCWgSfZPcD1sCArO3AYe80wY6cYY93dtA28AFISflFS3q2QeHAfP81lJzbBukU0QGVEh/KikS18+iYbnFsIPSqpGegv8yw9e9+Ur48vRdSg73KYvpaZblGyWj757aDPLfwAb/2J7O2+WigAAACV0RVh0ZGF0ZTpjcmVhdGUAMjAxNS0xMi0wMVQwNjoyNjo1NC0wNTowMCb0KyoAAAAldEVYdGRhdGU6bW9kaWZ5ADIwMTUtMTItMDFUMDY6MjY6NTQtMDU6MDBXqZOWAAAAAElFTkSuQmCC";
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(Helpers2.ColorFromHex961("#2E3243"));
                checked
                {
                    var num = TabPages.Count - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        BaseRect = GetTabRect(i);
                        var flag = SelectedIndex == i;
                        if (flag)
                        {
                            using (var solidBrush = new SolidBrush(Helpers2.ColorFromHex961("#272938")))
                            {
                                using (var solidBrush2 = new SolidBrush(Helpers2.ColorFromHex961("#E4E4E5")))
                                {
                                    using (var font = new Font("Segoe UI semibold", 9f))
                                    {
                                        G.FillRectangle(solidBrush, BaseRect.X - 6, BaseRect.Y + 1, BaseRect.Width + 9, BaseRect.Height - 1);
                                        G.DrawString(TabPages[i].Text, font, solidBrush2, new Point(BaseRect.X + 55, BaseRect.Y + 11));
                                    }
                                }
                            }
                            using (var solidBrush3 = new SolidBrush(Helpers2.ColorFromHex961("#2E3243")))
                            {
                                using (var pen = new Pen(Helpers2.ColorFromHex961("#232532")))
                                {
                                    using (var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(B64Arrow))))
                                    {
                                        G.FillPath(solidBrush3, Helpers2.RoundRect961(new Rectangle(BaseRect.X + 148, BaseRect.Y + 11, 17, 17), 3, Helpers2.RoundingStyle.All));
                                        G.DrawPath(pen, Helpers2.RoundRect961(new Rectangle(BaseRect.X + 148, BaseRect.Y + 11, 17, 17), 3, Helpers2.RoundingStyle.All));
                                        G.DrawImage(image, new Point(BaseRect.X + 153, BaseRect.Y + 15));
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (var solidBrush4 = new SolidBrush(Helpers2.ColorFromHex961("#848AA0")))
                            {
                                using (var font2 = new Font("Segoe UI semibold", 9f))
                                {
                                    G.DrawString(TabPages[i].Text, font2, solidBrush4, new Point(BaseRect.X + 55, BaseRect.Y + 11));
                                }
                            }
                        }
                        var flag2 = !string.IsNullOrEmpty(Conversions.ToString(TabPages[i].Tag));
                        if (!flag2) continue;
                        try
                        {
                            using (var pen2 = new Pen(Helpers2.ColorFromHex961(Conversions.ToString(TabPages[i].Tag)))
                            {
                                Width = 3f
                            })
                            {
                                G.DrawPath(pen2, Helpers2.RoundRect961(new Rectangle(BaseRect.X + 35, BaseRect.Y + 15, 9, 9), 2, Helpers2.RoundingStyle.All));
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    base.OnPaint(e);
                }
            }

            private Graphics G;

            private readonly string B64Arrow;
        }

        public sealed class Helpers2
        {
            public static void CenterString961(Graphics G, string T, Font F, Color C, Rectangle R)
            {
                var sizeF = G.MeasureString(T, F);
                using (var solidBrush = new SolidBrush(C))
                {
                    G.DrawString(T, F, solidBrush, checked(new Point((int)Math.Round(R.X + R.Width / 2.0 - sizeF.Width / 2f), (int)Math.Round(R.Y + R.Height / 2.0 - sizeF.Height / 2f))));
                }
            }

            public static Color ColorFromHex961(string Hex)
            {
                return Color.FromArgb(checked((int)long.Parse(string.Format("FFFFFFFFFF{0}", Hex.Substring(1)), NumberStyles.HexNumber)));
            }

            public static Rectangle FullRectangle961(Size S, bool Subtract)
            {
                var result = Subtract ? checked(new Rectangle(0, 0, S.Width - 1, S.Height - 1)) : new Rectangle(0, 0, S.Width, S.Height);
                return result;
            }

            public static GraphicsPath RoundRect961(Rectangle Rect, int Rounding, RoundingStyle Style = RoundingStyle.All)
            {
                var graphicsPath = new GraphicsPath();
                checked
                {
                    var num = Rounding * 2;
                    graphicsPath.StartFigure();
                    var flag = Rounding == 0;
                    GraphicsPath result;
                    if (flag)
                    {
                        graphicsPath.AddRectangle(Rect);
                        graphicsPath.CloseAllFigures();
                        result = graphicsPath;
                    }
                    else
                    {
                        switch (Style)
                        {
                            case RoundingStyle.All:
                                graphicsPath.AddArc(new Rectangle(Rect.X, Rect.Y, num, num), -180f, 90f);
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Y, num, num), -90f, 90f);
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Height - num + Rect.Y, num, num), 0f, 90f);
                                graphicsPath.AddArc(new Rectangle(Rect.X, Rect.Height - num + Rect.Y, num, num), 90f, 90f);
                                break;
                            case RoundingStyle.Top:
                                graphicsPath.AddArc(new Rectangle(Rect.X, Rect.Y, num, num), -180f, 90f);
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Y, num, num), -90f, 90f);
                                graphicsPath.AddLine(new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height), new Point(Rect.X, Rect.Y + Rect.Height));
                                break;
                            case RoundingStyle.Bottom:
                                graphicsPath.AddLine(new Point(Rect.X, Rect.Y), new Point(Rect.X + Rect.Width, Rect.Y));
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Height - num + Rect.Y, num, num), 0f, 90f);
                                graphicsPath.AddArc(new Rectangle(Rect.X, Rect.Height - num + Rect.Y, num, num), 90f, 90f);
                                break;
                            case RoundingStyle.Left:
                                graphicsPath.AddArc(new Rectangle(Rect.X, Rect.Y, num, num), -180f, 90f);
                                graphicsPath.AddLine(new Point(Rect.X + Rect.Width, Rect.Y), new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height));
                                graphicsPath.AddArc(new Rectangle(Rect.X, Rect.Height - num + Rect.Y, num, num), 90f, 90f);
                                break;
                            case RoundingStyle.Right:
                                graphicsPath.AddLine(new Point(Rect.X, Rect.Y + Rect.Height), new Point(Rect.X, Rect.Y));
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Y, num, num), -90f, 90f);
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Height - num + Rect.Y, num, num), 0f, 90f);
                                break;
                            case RoundingStyle.TopRight:
                                graphicsPath.AddLine(new Point(Rect.X, Rect.Y + 1), new Point(Rect.X, Rect.Y));
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Y, num, num), -90f, 90f);
                                graphicsPath.AddLine(new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height - 1), new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height));
                                graphicsPath.AddLine(new Point(Rect.X + 1, Rect.Y + Rect.Height), new Point(Rect.X, Rect.Y + Rect.Height));
                                break;
                            case RoundingStyle.BottomRight:
                                graphicsPath.AddLine(new Point(Rect.X, Rect.Y + 1), new Point(Rect.X, Rect.Y));
                                graphicsPath.AddLine(new Point(Rect.X + Rect.Width - 1, Rect.Y), new Point(Rect.X + Rect.Width, Rect.Y));
                                graphicsPath.AddArc(new Rectangle(Rect.Width - num + Rect.X, Rect.Height - num + Rect.Y, num, num), 0f, 90f);
                                graphicsPath.AddLine(new Point(Rect.X + 1, Rect.Y + Rect.Height), new Point(Rect.X, Rect.Y + Rect.Height));
                                break;
                        }
                        graphicsPath.CloseAllFigures();
                        result = graphicsPath;
                    }
                    return result;
                }
            }

            public enum MouseState961 : byte
            {
                None,
                Over,
                Down
            }

            public enum RoundingStyle : byte
            {
                All,
                Top,
                Bottom,
                Left,
                Right,
                TopRight,
                BottomRight
            }
        }

        public sealed class RunTimeModule
        {

            public static Form MainForm;
            public static string Appver;
            public static string appname961;
            public static string GetAppVer;
            public static string logchk;
            private static bool SaveLic961 = true;
            private static readonly Form Login961 = new Form();
            private static readonly Form AutoUpdate961 = new Form();
            private static readonly StrafeTabControl StrafeTabControl1 = new StrafeTabControl();
            private static readonly TabPage TabPage1 = new TabPage();
            private static readonly TabPage TabPage2 = new TabPage();
            private static readonly TabPage TabPage3 = new TabPage();
            private static readonly GroupBox GroupBox1 = new GroupBox();
            private static readonly GroupBox GroupBox2 = new GroupBox();
            private static readonly GroupBox GroupBox3 = new GroupBox();
            private static readonly Label Label1 = new Label();
            private static readonly Label Label2 = new Label();
            private static readonly Label Label3 = new Label();
            private static readonly Label Label4 = new Label();
            private static readonly Label Label5 = new Label();
            private static readonly Label Label6 = new Label();
            private static readonly Label Label7 = new Label();
            private static readonly Label Label8 = new Label();
            private static readonly Label Label9 = new Label();
            private static readonly Label Label10 = new Label();
            private static readonly Label Label11 = new Label();
            private static readonly Label Label12 = new Label();
            private static readonly Label Label13 = new Label();
            private static readonly Label Label14 = new Label();
            private static readonly TextBox TextBox1 = new TextBox();
            private static readonly TextBox TextBox2 = new TextBox();
            private static readonly TextBox TextBox3 = new TextBox();
            private static readonly StrafeOnOffBox StrafeOnOffBox1 = new StrafeOnOffBox();
            private static readonly Button Button1 = new Button();
            private static readonly Button Button2 = new Button();
            private static readonly Button Button4 = new Button();
            private static readonly RichTextBox RichTextBox1 = new RichTextBox();

            public static void Control961()
            {

                Login961.Text = "961API - License Client";
                Login961.Width = 635;
                Login961.Height = 221;
                Login961.MaximumSize = new Size(635, 221);
                Login961.MinimumSize = new Size(635, 221);
                Login961.StartPosition = FormStartPosition.CenterScreen;
                Login961.ShowIcon = false;
                Login961.ShowInTaskbar = false;
                Login961.MaximizeBox = false;
                Login961.MinimizeBox = false;
                AutoUpdate961.Text = "Auto Update";
                AutoUpdate961.Width = 377;
                AutoUpdate961.Height = 159;
                AutoUpdate961.MaximumSize = new Size(377, 159);
                AutoUpdate961.MinimumSize = new Size(377, 159);
                AutoUpdate961.StartPosition = FormStartPosition.CenterScreen;
                AutoUpdate961.ShowIcon = false;
                AutoUpdate961.ShowInTaskbar = false;
                AutoUpdate961.MaximizeBox = false;
                AutoUpdate961.MinimizeBox = false;
                Label1.Text = "License Key";
                Label1.Location = new Point(8, 25);
                Label1.Width = 71;
                Label1.Height = 15;
                Label2.Text = "NO";
                Label2.Location = new Point(369, 55);
                Label2.Width = 25;
                Label2.Height = 15;
                Label2.Visible = false;
                Label2.BackColor = Color.FromArgb(200, 200, 200);
                Label2.ForeColor = Color.FromArgb(114, 119, 141);
                Label3.Text = "YES";
                Label3.Location = new Point(328, 55);
                Label3.Width = 26;
                Label3.Height = 15;
                Label3.BackColor = Color.FromArgb(64, 177, 208);
                Label3.ForeColor = Color.Black;
                Label4.Text = "Save License Key";
                Label4.Location = new Point(222, 55);
                Label4.Width = 95;
                Label4.Height = 15;
                Label5.Text = "Email:";
                Label5.Location = new Point(8, 25);
                Label5.Width = 39;
                Label5.Height = 15;
                Label6.Text = "License Key:";
                Label6.Location = new Point(8, 54);
                Label6.Width = 75;
                Label6.Height = 15;
                Label7.Text = "Your Version:";
                Label7.Location = new Point(6, 19);
                Label7.Width = 75;
                Label7.Height = 15;
                Label8.Text = "Current Version:";
                Label8.Location = new Point(6, 35);
                Label8.Width = 91;
                Label8.Height = 15;
                Label9.Text = "N/A";
                Label9.Location = new Point(94, 19);
                Label9.Width = 35;
                Label9.Height = 15;
                Label10.Text = "N/A";
                Label10.Location = new Point(94, 35);
                Label10.Width = 35;
                Label10.Height = 15;
                Label11.Text = "Discription";
                Label11.Location = new Point(6, 61);
                Label11.Width = 64;
                Label11.Height = 15;
                Label12.Text = "Good News!";
                Label12.Location = new Point(130, 9);
                Label12.Width = 102;
                Label12.Height = 21;
                Label12.ForeColor = Color.FromArgb(114, 119, 141);
                Label12.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                Label13.Text = "There is a new update for this tool." + "\r\n" + "\r\n" + "Please click on the " + "\"" + "Update Check" + "\"" + " tab to download it.";
                Label13.Location = new Point(12, 41);
                Label13.Width = 340;
                Label13.Height = 57;
                Label13.ForeColor = Color.FromArgb(114, 119, 141);
                Label13.Font = new Font("Segoe UI", 10);
                Label13.TextAlign = ContentAlignment.TopCenter;
                Label14.Text = "";
                Label14.Location = new Point(6, 128);
                Label14.AutoSize = false;
                Label14.Width = 416;
                Label14.Height = 43;
                Label14.ForeColor = Color.Red;
                Label14.TextAlign = ContentAlignment.TopCenter;
                AutoUpdate961.Controls.Add(Label12);
                AutoUpdate961.Controls.Add(Label13);
                StrafeTabControl1.Location = new Point(0, 0);
                StrafeTabControl1.Width = 619;
                StrafeTabControl1.Height = 182;
                TabPage1.Text = "Login";
                TabPage2.Text = "Register";
                TabPage3.Text = "Update Check";
                GroupBox1.Location = new Point(9, 9);
                GroupBox1.Width = 413;
                GroupBox1.Height = 116;
                GroupBox1.Visible = true;
                GroupBox1.Text = "Login";
                GroupBox2.Location = new Point(9, 9);
                GroupBox2.Width = 413;
                GroupBox2.Height = 116;
                GroupBox2.Visible = true;
                GroupBox2.Text = "Activate License";
                GroupBox3.Location = new Point(9, 9);
                GroupBox3.Width = 413;
                GroupBox3.Height = 159;
                GroupBox3.Visible = true;
                GroupBox3.Text = "Update Check";
                TextBox1.Location = new Point(85, 22);
                TextBox1.Width = 313;
                TextBox1.Height = 23;
                TextBox2.Location = new Point(85, 22);
                TextBox2.Width = 313;
                TextBox2.Height = 23;
                TextBox3.Location = new Point(85, 51);
                TextBox3.Width = 313;
                TextBox3.Height = 23;
                Button1.Text = "Access";
                Button1.Location = new Point(323, 80);
                Button1.Width = 75;
                Button1.Height = 23;
                Button1.BackColor = SystemColors.ActiveBorder;
                Button1.ForeColor = Color.FromArgb(114, 119, 141);
                Button1.Click += Login961Click;
                Button2.Text = "Activate";
                Button2.Location = new Point(322, 80);
                Button2.Width = 75;
                Button2.Height = 23;
                Button2.BackColor = SystemColors.ControlLight;
                Button2.Click += Activate961;
                Button4.Text = "Update";
                Button4.Location = new Point(332, 22);
                Button4.Width = 75;
                Button4.Height = 23;
                Button4.BackColor = SystemColors.ControlLight;
                Button4.Visible = false;
                Button4.Click += Update961;
                StrafeOnOffBox1.Location = new Point(323, 51);
                StrafeOnOffBox1.Width = 75;
                StrafeOnOffBox1.Height = 23;
                StrafeOnOffBox1.Checked = true;
                StrafeOnOffBox1.Click += StrafeOnOffBox1_clickit;
                RichTextBox1.Text = CSharpAPI.AppVersionDescription;
                RichTextBox1.Location = new Point(6, 77);
                RichTextBox1.Width = 401;
                RichTextBox1.Height = 76;
                RichTextBox1.ReadOnly = true;
                GroupBox1.Controls.Add(Label1);
                GroupBox1.Controls.Add(Label2);
                GroupBox1.Controls.Add(Label3);
                GroupBox1.Controls.Add(Label4);
                GroupBox1.Controls.Add(TextBox1);
                GroupBox1.Controls.Add(Button1);
                GroupBox1.Controls.Add(StrafeOnOffBox1);
                GroupBox2.Controls.Add(Label5);
                GroupBox2.Controls.Add(Label6);
                GroupBox2.Controls.Add(TextBox2);
                GroupBox2.Controls.Add(TextBox3);
                GroupBox2.Controls.Add(Button2);
                GroupBox3.Controls.Add(Label7);
                GroupBox3.Controls.Add(Label8);
                GroupBox3.Controls.Add(Label9);
                GroupBox3.Controls.Add(Label10);
                GroupBox3.Controls.Add(Label11);
                GroupBox3.Controls.Add(Button4);
                GroupBox3.Controls.Add(RichTextBox1);
                TabPage1.Controls.Add(GroupBox1);
                TabPage2.Controls.Add(GroupBox2);
                TabPage3.Controls.Add(GroupBox3);
                TabPage1.Controls.Add(Label14);
                Login961.Controls.Add(StrafeTabControl1);
                StrafeTabControl1.Controls.Add(TabPage1);
                StrafeTabControl1.Controls.Add(TabPage2);
                StrafeTabControl1.Controls.Add(TabPage3);

                Login961.Show();
                logchk = "YES";
                MainForm.Opacity = 0;
                MainForm.ShowInTaskbar = false;
                GetAppName961();

            }

            private static void Activate961(object sender, EventArgs e)
            {

                if (TextBox2.Text == null || TextBox3.Text == null)
                {
                    MessageBox.Show("Enter Your Email And License Key");
                }
                else
                {
                    CSharpAPI.ActivateLicense(TextBox3.Text, TextBox2.Text);
                }

            }

            private static void Update961(object sender, EventArgs e)
            {

                var sfd = new SaveFileDialog { FileName = Path.GetFileName(CSharpAPI.Appurl) };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    (new Computer()).Network.DownloadFile(CSharpAPI.Appurl, sfd.FileName);
                }
                MessageBox.Show("Updated file downloaded to " + sfd.FileName + "\r\n" + "\r\n" + "Please close this program And run the updated version." + "\r\n");

            }

            public static void Loginchk()
            {

                if (logchk == "YES")
                {
                }
                else
                {
                    Control961();
                }

            }

            private static void GetAppName961()
            {

                var appamesplit = AppDomain.CurrentDomain.FriendlyName.Split('.');
                appname961 = appamesplit[0];
                var CheckKeyDir = (new Computer()).Registry.CurrentUser.OpenSubKey("961API" + "-" + appname961, true);
                if (ReferenceEquals(CheckKeyDir, null))
                {
                    (new Computer()).Registry.CurrentUser.CreateSubKey("961API" + "-" + appname961 + "\\activated");
                    (new Computer()).Registry.SetValue("HKEY_CURRENT_USER\\961API" + "-" + appname961 + "\\activated", "Check", "False");
                }
                else
                {
                    TextBox1.Text = Convert.ToString((new Computer()).Registry.GetValue("HKEY_CURRENT_USER\\961API" + "-" + appname961 + "\\login", "key", true));
                }
                GetAppVer = CSharpAPI.AppVersion;
                if (Appver == GetAppVer)
                {
                }
                else
                {
                    AutoUpdatechk();
                }
                Label9.Text = Appver;
                Label10.Text = GetAppVer;

            }

            private static void AutoUpdatechk()
            {

                AutoUpdate961.Show();
                Button4.Visible = true;

            }

            private static void StrafeOnOffBox1_clickit(object sender, EventArgs e)
            {

                StrafeOnOffBox1.SendToBack();
                if (StrafeOnOffBox1.Checked)
                {
                    Label2.Visible = true;
                    Label3.Visible = false;
                    SaveLic961 = false;
                }
                else
                {
                    Label2.Visible = false;
                    Label3.Visible = true;
                    SaveLic961 = true;
                }

            }

            private static void Login961Click(object sender, EventArgs e)
            {
                Button1.Enabled = false;
                (new Computer()).Registry.SetValue("HKEY_CURRENT_USER\\961API" + "-" + appname961 + "\\login", "Key",
                    SaveLic961 ? TextBox1.Text : "");
                if (CSharpAPI.Systemcheck() != CSharpAPI.InitializeSecurity) return;
                var License = TextBox1.Text.Replace(" ", "");
                if (!(string.IsNullOrEmpty(License)))
                {
                    CSharpAPI.LicenseKey = License;
                    if (CSharpAPI.CheckLicense(License) == (CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("3x1wwe3NXOPOBNvOBNczXIY=fbzbyLzbwAQ5z0zdfSzdf7GG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")))))
                    {
                        (new Computer()).Registry.SetValue("HKEY_CURRENT_USER\\961API" + "-" + appname961 + "\\activated", "Check", "True");
                        MainForm.Opacity = 1;
                        MainForm.ShowInTaskbar = true;
                        Login961.Close();
                        CSharpAPI.Livesystemcheck();
                    }
                    else if (CSharpAPI.CheckLicense(License) == (CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("AJ1Ncgc+CFQrgIhAyMcR8JYBqdfVBO1ZcgCJcgCJ").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")))))
                    {
                        Button1.Enabled = true;
                        Label14.Text = CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("BzlfDTZZguQwqWJrwJFRz0zbyNhVqd3R8JAu0RzbyIODBTvxfM1kgRzbfNKmCK3BzWflXW3ICrQvzL1xzuKWfK3W0Wzry/GG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")));
                    }
                    else if (CSharpAPI.CheckLicense(License) == (CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("XuwC8JhWyLwNfIO+ydCzq8fA0KcFy0zdfSzdf7GG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")))))
                    {
                        Button1.Enabled = true;
                        Label14.Text = CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("DWZ8cgcSB+h0agOCau3YDreYDzFKquwZcgCJcgCJ").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")));
                    }
                    else if (CSharpAPI.CheckLicense(License) == (CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("AIwN3zBhg8wYBxNrC8OOcgc+fzKKaJcZcgCJcgCJ").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")))))
                    {
                        Button1.Enabled = true;
                        Label14.Text = CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("BzlfDTZZguQwqWJrwJFRz0zbyNhVqd3Owu1DwgBYAMKC8ufuENl=CAZ=BdK03rcB0bzbyL1=qT3uBg3VDLw0cgcSX8Fwzu3=8RzbyRzbfIyFqdfUBNYg0elTALzOBNw0B+qOBeyOBeyG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?"))) + "\r\n" + CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("f+3sETZ+E8ndX85OBNcADuveBNnYcgcSCxc4qRzbyOK=BdAv3xcQvM7F8zfD0xKZEbzdf7GG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")));
                    }
                    else if (CSharpAPI.CheckLicense(License) == (CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("wLKhg+AvA+Y0AeChg+3RgNFuzgA4y0zdfSzdf7GG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")))))
                    {
                        Button1.Enabled = true;
                        Label14.Text = CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("ELZCXIAywuCx8NQuCIYN3z1ecgcSEr1K8KP2fFw8C8fTgxcfyxCx0zPYgLK4cgCJ").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")));
                    }
                    else if (CSharpAPI.CheckLicense(License) == (CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("3u1iguAY08QQzr/dB8n=0OCBqzhzz0zdfSzdf7GG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")))))
                    {
                        Button1.Enabled = true;
                        Label14.Text = CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("azhWBzlk3zK0zJl0gen0CKQd88kdwz/x3FCw0MNYCFZLfdC6DTfr3LQfwbzdf7GG").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?"))) + "\r\n" + CSharpAPI.LicenseNote;
                    }
                    else
                    {
                        Button1.Enabled = true;
                        Label14.Text = CSharpAPI.CheckLicense(License);
                    }
                }
                else
                {
                    Button1.Enabled = true;
                    Label14.Text = CSharpAPI.Éõö(Convert.ToString(CSharpAPI.Éëê("BrhYfbzbyNOIDew08MfvDdK6AxAuaAfKDxQRCxwwDKCu3WZUfdye0Af2BuAccgCJ").Replace("%22", "\"").Replace("%C2%A3", "£").Replace("%24", "$").Replace("%25", "%").Replace("%5E", "^").Replace("%26", "&").Replace("%3D", "=").Replace("%2B", "+").Replace("%5B", "[").Replace("%7B", "{").Replace("%5D", "]").Replace("%7D", "}").Replace("%3B", ";").Replace("%40", "@").Replace("%23", "#").Replace("%2C", ",").Replace("%3C", "<").Replace("%3E", ">").Replace("%5C", "\\").Replace("%7C", "|").Replace("%20", " ").Replace("%3A", ":").Replace("%2F", "/").Replace("%3F", "?")));
                }
            }
        }

        public class ThreadWithState
        {
            public static CallBack callback;

            public ThreadWithState(Thread self, CallBack callbackDelegate)
            {
                currentThread = self;
                callback = callbackDelegate;
            }

            public ThreadWithState(object p, CSharpAPI.CallBack callBack)
            {
            }

            public void ThreadProc()
            {
                var flag = callback != null;
                if (flag)
                {
                    callback(currentThread);
                }
            }

            private readonly Thread currentThread;

        }

        public sealed class CSharpAPI
        {
            public delegate void CallBack(Thread currentThread);

            private const string Checksum = "/ca/checksum/";

            private const string WebApiPath = "/v1/";

            private const string WebAppApi = "/ca/application/";

            private const string WebAppSv = "/ca/sv/";

            private const string WebLicenseApi = "/cl/license/";

            private const string WebLiveSystem = "/cl/livesystem/";

            private const string WebPath = "https://www.api.961API.com";

            private const string WebPortal = "https://www.961API.com/portal/";

            private static string _integrity;

            private static object _appCheckSum;

            private static object _appHwid;

            private static readonly object _AppHWID = GetHwid();


            static CSharpAPI()
            {
                TesterToken = "BYPASSFALSE";
                LicenseKey = "NULL";
                AppCheckSum = RuntimeHelpers.GetObjectValue(GetFileChecksum());
                AppHwid = GetHwid();
                Authenticated = false;
            }

            public static object AppCheckSum
            {
                get { return _appCheckSum; }
                set { _appCheckSum = RuntimeHelpers.GetObjectValue(value); }
            }

            public static string AppDescription { get; set; }

            public static object AppHwid
            {
                get { return _appHwid; }
                set { _appHwid = RuntimeHelpers.GetObjectValue(value); }
            }

            public static string AppName { get; set; }

            public static string AppToken { get; set; }

            public static string Appurl { get; set; }

            public static string AppVersion { get; set; }

            public static string AppVersionDescription { get; set; }

            public static bool Authenticated { get; set; }

            public static string CustomerCountry { get; set; }

            public static string CustomerEmail { get; set; }

            public static string CustomerName { get; set; }

            public static string CustomerPhone { get; set; }

            public static string DeviceCountry { get; set; }

            public static string DeviceIp { get; set; }

            public static string DeviceName { get; set; }

            public static string DeviceUsed { get; set; }

            public static string InitializeSecurity { get; set; }

            public static string LicenseKey { get; set; }

            public static string LicenseActivatedOn { get; set; }

            public static string LicenseCreatedOn { get; set; }

            public static string LicenseExpirationDate { get; set; }

            public static string LicenseExpirationDateDayLeft { get; set; }

            public static string LicenseNote { get; set; }

            public static string RuleDevice { get; set; }

            public static string RuleName { get; set; }

            public static string RuleTime { get; set; }

            public static string SecretToken { get; set; }

            public static string Slogan { get; set; }

            public static string Status { get; set; }

            public static string SubDomain { get; set; }

            public static string TesterToken { get; set; }

            private static object GetAppHWID()
            {
                return _AppHWID;
            }

            private static readonly object oSName = getOSName();

            public static object GetOSName()
            {
                return oSName;
            }

            private static readonly string uICultureDisplayName = getUICultureDisplayName();

            public static string GetUICultureDisplayName()
            {
                return uICultureDisplayName;
            }

            public static string getUICultureDisplayName()
            {
                string result;
                try
                {

                    result = CultureInfo.InstalledUICulture.DisplayName;
                }
                catch (Exception)
                {
                    result = "False";
                }
                return result;
            }

            private static string GetOSFriendlyName()
            {
                var result = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
                foreach (var o in searcher.Get())
                {
                    var os = (ManagementObject)o;
                    result = os["Caption"].ToString();
                    break;
                }
                return result;
            }

            public static string getOSName()
            {
                string result;
                try
                {
                    result = GetOSFriendlyName();//MyProject.Computer.Info.OSFullName;
                }
                catch (Exception)
                {
                    var text = Environment.OSVersion.ToString();
                    result = text;
                }
                return result;
            }

            private static readonly string oSPlatform = getOSPlatform();

            public static string GetOSPlatform()
            {
                return oSPlatform;
            }

            public static string getOSPlatform()
            {
                string result;
                try
                {
                    Computer myComputer = new Computer();
                    result = myComputer.Info.OSPlatform;//MyProject.Computer.Info.OSPlatform;
                }
                catch (Exception)
                {
                    result = "False";
                }
                return result;
            }

            public static object ActivateLicense(string licenseKey, string email)
            {
                Process.Start(Convert.ToString(Convert.ToString(Operators.ConcatenateObject(
                    Operators.ConcatenateObject(
                        Operators.ConcatenateObject(
                            Operators.ConcatenateObject(
                                Operators.ConcatenateObject(
                                    string.Concat(WebPortal, SubDomain, "/Activate/", LicenseKey, "/"), GetAppHWID()), "/"),
                            new Computer().Name), "/"), email))));
                return null;
            }

            private static string BackHwid()
            {
                var theInput = Pack(string.Concat(CpuId(), BiosId(), DiskId(), BaseId(), VideoId(), MacId()));
                return GetHash(theInput);
            }

            private static object BASE64_Decode(string input)
            {
                var b = Convert.FromBase64String(input);
                return Encoding.UTF8.GetString(b);
            }

            private static string BASE64_Encode(string input)
            {
                return Convert.ToBase64String(Encoding.ASCII.GetBytes(input));
            }

            private static string BaseId()
            {
                return Identifier("Win32_BaseBoard", "Model") + Identifier("Win32_BaseBoard", "Manufacturer") +
                       Identifier("Win32_BaseBoard", "Name") + Identifier("Win32_BaseBoard", "SerialNumber");
            }

            private static string BiosId()
            {
                return string.Concat(Identifier("Win32_DiskDrive", "Model"),
                    Identifier("Win32_DiskDrive", "Manufacturer"),
                    Identifier("Win32_DiskDrive", "Signature"),
                    Identifier("Win32_DiskDrive", "TotalHeads"));
            }

            public static string CheckLicense(object licenseKey)
            {
                try
                {
                    var webRequest = (WebRequest)NewLateBinding.LateGet(null, typeof(WebRequest), "Create", new[]
                    {
                    Operators.ConcatenateObject(
                        Operators.ConcatenateObject(
                            Operators.ConcatenateObject(
                                Operators.ConcatenateObject(
                                    Operators.ConcatenateObject(
                                        Operators.ConcatenateObject(
                                            Operators.ConcatenateObject(
                                                string.Concat(WebPath, WebApiPath, SecretToken, WebLicenseApi, AppToken,
                                                    "/"), licenseKey), Operators.AddObject("/", _AppHWID)), "/"),
                                    AppCheckSum), "/"), TesterToken), ".xml")
                }, null, null, null);

                    webRequest.Timeout = 60000;
                    webRequest.Proxy = null;
                    var response = webRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var xmlDocument = new XmlDocument();
                    var flag = responseStream != null;
                    if (flag)
                    {
                        xmlDocument.Load(responseStream);
                        var xmlNode = xmlDocument.SelectSingleNode("//response/Status");
                        var flag2 = xmlNode != null;
                        if (flag2)
                        {
                            var text = Decrypt(xmlNode.InnerText);
                            response.Close();
                            responseStream.Close();
                            Authenticated = false;
                            var flag3 = Operators.CompareString(text, "SUSPENDED", false) == 0;

                            if (flag3)
                            {
                                var xmlNode2 = xmlDocument.SelectSingleNode("//response/License_Note");
                                var flag4 = xmlNode2 != null;
                                if (flag4)
                                    LicenseNote = Decrypt(xmlNode2.InnerText);
                                return text.ToUpper();
                            }
                            var flag5 = Operators.CompareString(text, "ACTIVE", false) != 0;
                            if (flag5)
                                return text.ToUpper();
                            Authenticated = true;
                            Status = Decrypt(xmlNode.InnerText);
                            var xmlNode3 = xmlDocument.SelectSingleNode("//response/License_Note");
                            var flag6 = xmlNode3 != null;
                            if (flag6)
                                LicenseNote = Decrypt(xmlNode3.InnerText);

                            var xmlNode4 = xmlDocument.SelectSingleNode("//response/_integrity");
                            var flag7 = xmlNode4 != null;
                            if (flag7)
                                _integrity = xmlNode4.InnerText;

                            var xmlNode5 = xmlDocument.SelectSingleNode("//response/License");
                            var flag8 = xmlNode5 != null;
                            if (flag8)
                                LicenseKey = Decrypt(xmlNode5.InnerText);

                            var xmlNode6 = xmlDocument.SelectSingleNode("//response/License_Created_On");
                            var flag9 = xmlNode6 != null;
                            if (flag9)
                                LicenseCreatedOn = Decrypt(xmlNode6.InnerText);

                            var xmlNode7 = xmlDocument.SelectSingleNode("//response/License_Activated_On");
                            var flag10 = xmlNode7 != null;
                            if (flag10)
                                LicenseActivatedOn = Decrypt(xmlNode7.InnerText);

                            var xmlNode8 = xmlDocument.SelectSingleNode("//response/License_Expiration_Date");
                            var flag11 = xmlNode8 != null;
                            if (flag11)
                                LicenseExpirationDate = Decrypt(xmlNode8.InnerText);

                            var xmlNode9 = xmlDocument.SelectSingleNode("//response/License_Expiration_Date_Day_Left");
                            var flag12 = xmlNode9 != null;
                            if (flag12)
                                LicenseExpirationDateDayLeft = Decrypt(xmlNode9.InnerText);

                            var nodeCustomerName = xmlDocument.SelectSingleNode("//response/Customer_Name");
                            var flag13 = nodeCustomerName != null;
                            if (flag13)
                                CustomerName = Decrypt(nodeCustomerName.InnerText);

                            var nodeCustomerEmail = xmlDocument.SelectSingleNode("//response/Customer_Email");
                            var flag14 = nodeCustomerEmail != null;
                            if (flag14)
                                CustomerEmail = Decrypt(nodeCustomerEmail.InnerText);

                            var nodeCustomerPhone = xmlDocument.SelectSingleNode("//response/Customer_Phone");
                            var flag15 = nodeCustomerPhone != null;
                            if (flag15)
                                CustomerPhone = Decrypt(nodeCustomerPhone.InnerText);

                            var nodeCustomerCountry = xmlDocument.SelectSingleNode("//response/Customer_Country");
                            var flag16 = nodeCustomerCountry != null;
                            if (flag16)
                                CustomerCountry = Decrypt(nodeCustomerCountry.InnerText);

                            var nodeRuleName = xmlDocument.SelectSingleNode("//response/Rule_Name");
                            var flag17 = nodeRuleName != null;
                            if (flag17)
                                RuleName = Decrypt(nodeRuleName.InnerText);

                            var nodeRuleTime = xmlDocument.SelectSingleNode("//response/Rule_Time");
                            var flag18 = nodeRuleTime != null;
                            if (flag18)
                                RuleTime = Decrypt(nodeRuleTime.InnerText);

                            var nodeRuleDevice = xmlDocument.SelectSingleNode("//response/Rule_Device");
                            var flag19 = nodeRuleDevice != null;
                            if (flag19)
                                RuleDevice = Decrypt(nodeRuleDevice.InnerText);

                            var nodeDeviceUsed = xmlDocument.SelectSingleNode("//response/Device_Used");
                            var flag20 = nodeDeviceUsed != null;
                            if (flag20)
                                DeviceUsed = Decrypt(nodeDeviceUsed.InnerText);

                            var nodeDeviceName = xmlDocument.SelectSingleNode("//response/Device_Name");
                            var flag21 = nodeDeviceName != null;
                            if (flag21)
                                DeviceName = Decrypt(nodeDeviceName.InnerText);

                            var nodeDeviceCountry = xmlDocument.SelectSingleNode("//response/Device_Country");
                            var flag22 = nodeDeviceCountry != null;
                            if (flag22)
                                DeviceCountry = Decrypt(nodeDeviceCountry.InnerText);

                            var nodeDeviceIp = xmlDocument.SelectSingleNode("//response/Device_IP");
                            var flag23 = nodeDeviceIp != null;
                            if (flag23)
                                DeviceIp = Decrypt(nodeDeviceIp.InnerText);
                            return LicenseIntegrityCheck() ? "ACTIVE" : text;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                return null;
            }

            private static string CpuId()
            {
                var retVal = Identifier("Win32_Processor", "UniqueId");
                var flag = Operators.CompareString(retVal, "", false) == 0;
                if (flag)
                {
                    retVal = Identifier("Win32_Processor", "ProcessorId");
                    var flag2 = Operators.CompareString(retVal, "", false) == 0;
                    if (flag2)
                    {
                        retVal = Identifier("Win32_Processor", "Name");
                        var flag3 = Operators.CompareString(retVal, "", false) == 0;
                        if (flag3)
                            retVal = Identifier("Win32_Processor", "Manufacturer");
                        retVal += Identifier("Win32_Processor", "MaxClockSpeed");
                    }
                }
                return retVal;
            }

            public static string CreateRandomPassword(int passwordLength)
            {
                const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                checked
                {
                    var array = new char[passwordLength - 1 + 1];
                    var num = passwordLength - 1;
                    for (var i = 0; i <= num; i++)
                        array[i] = allowedChars[
                            (int)Math.Round(Conversion.Fix(allowedChars.Length * random.NextDouble()))];
                    return new string(array);
                }
            }

            private static string Decrypt(string decryptor)
            {
                var decryptKey = new TripleDESCryptoServiceProvider();
                string decrypt;
                try
                {
                    var key = AppToken + LicenseKey;
                    decryptKey.Key = Md5Hash(key);
                    decryptKey.Mode = CipherMode.ECB;
                    var buffer = Convert.FromBase64String(decryptor);
                    decrypt = Encoding.ASCII.GetString(decryptKey.CreateDecryptor()
                        .TransformFinalBlock(buffer, 0, buffer.Length));
                }
                catch (Exception expr51)
                {
                    ProjectData.SetProjectError(expr51);
                    var ex = expr51;
                    decrypt = ex.ToString();
                    ProjectData.ClearProjectError();
                }
                return decrypt;
            }

            private static string DiskId()
            {
                return Identifier("Win32_DiskDrive", "Model") + Identifier("Win32_DiskDrive", "Manufacturer") +
                       Identifier("Win32_DiskDrive", "Signature") + Identifier("Win32_DiskDrive", "TotalHeads");
            }

            private static void ErrorMessage(string message)
            {
                MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            public static string GetApplication()
            {
                try
                {
                    var webRequest = (WebRequest)NewLateBinding.LateGet(null, typeof(WebRequest), "Create", new[]
                    {
                    Operators.AddObject(
                        Operators.ConcatenateObject(
                            Operators.ConcatenateObject(
                                Operators.ConcatenateObject(
                                    string.Concat(WebPath, WebApiPath, SecretToken, WebAppApi, AppToken, "/"),
                                    AppCheckSum), "/"), TesterToken), ".xml")
                }, null, null, null);
                    webRequest.Timeout = 60000;
                    webRequest.Proxy = null;
                    var response = webRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var xmlDocument = new XmlDocument();
                    var flag = responseStream != null;
                    if (flag)
                    {
                        xmlDocument.Load(responseStream);
                        var xmlNode = xmlDocument.SelectSingleNode("//response/Status");
                        var flag2 = xmlNode != null;
                        if (flag2)
                        {
                            var innerText = xmlNode.InnerText;
                            response.Close();
                            responseStream.Close();
                            var flag3 = Operators.CompareString(innerText, "EMERGENCY", false) == 0;
                            if (flag3)
                                ErrorMessage("04:ACCESS IS RESTRICTED,TRY AGAIN LATER");
                        }
                    }
                    var xmlNode2 = xmlDocument.SelectSingleNode("//response/name");
                    var flag4 = xmlNode2 != null;
                    if (!flag4) return Convert.ToString(true);
                    var innerText2 = xmlNode2.InnerText;

                    var xmlNode3 = xmlDocument.SelectSingleNode("//response/subdomain");
                    var flag5 = xmlNode3 != null;
                    if (!flag5) return Convert.ToString(true);
                    var innerText3 = xmlNode3.InnerText;

                    var xmlNode4 = xmlDocument.SelectSingleNode("//response/description");
                    var flag6 = xmlNode4 != null;
                    if (!flag6) return Convert.ToString(true);
                    var innerText4 = xmlNode4.InnerText;

                    var xmlNode5 = xmlDocument.SelectSingleNode("//response/slogan");
                    var flag7 = xmlNode5 != null;
                    if (!flag7) return Convert.ToString(true);
                    var innerText5 = xmlNode5.InnerText;

                    var xmlNode6 = xmlDocument.SelectSingleNode("//response/version");
                    var flag8 = xmlNode6 != null;
                    if (!flag8) return Convert.ToString(true);
                    var innerText6 = xmlNode6.InnerText;

                    var xmlNode7 = xmlDocument.SelectSingleNode("//response/url");
                    var flag9 = xmlNode7 != null;
                    if (!flag9) return Convert.ToString(true);
                    var innerText7 = xmlNode7.InnerText;

                    var xmlNode8 = xmlDocument.SelectSingleNode("//response/VersionDescription");
                    var flag10 = xmlNode8 != null;
                    if (!flag10) return Convert.ToString(true);
                    var innerText8 = xmlNode8.InnerText;

                    AppName = innerText2;
                    SubDomain = innerText3;
                    AppDescription = innerText4;
                    Slogan = innerText5;
                    AppVersion = innerText6;
                    Appurl = innerText7;
                    AppVersionDescription = innerText8;
                    return Convert.ToString(true);
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                return null;
            }

            private static object GetCpuid()
            {
                var cpuInfo = string.Empty;
                var mc = new ManagementClass("win32_processor");
                var moc = mc.GetInstances();
                var enumerator = moc.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var o = enumerator.Current;
                    var mo = (ManagementObject)o;
                    cpuInfo = Convert.ToString(mo.Properties["processorID"].Value.ToString());
                }
                return cpuInfo;
            }

            private static object GetFileChecksum()
            {
                return RuntimeHelpers.GetObjectValue(sha_256(Application.ExecutablePath));
            }

            private static string GetHash(string theInput)
            {
                checked
                {
                    string getHash;
                    using (var hasher = MD5.Create())
                    {
                        var dbytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput));
                        var sBuilder = new StringBuilder();
                        var num = dbytes.Length - 1;
                        for (var i = 0; i <= num; i++)
                            sBuilder.Append(dbytes[i].ToString("X2"));
                        getHash = sBuilder.ToString();
                    }
                    return getHash;
                }
            }

            public static string GetHwid()
            {
                string getHwid;
                try
                {
                    var hwid = BASE64_Encode(Convert.ToString(RuntimeHelpers.GetObjectValue(GetCpuid())));
                    var flag = hwid.Contains(" ");
                    if (flag)
                        hwid = hwid.Replace(" ", "");
                    getHwid = Convert.ToBase64String(new ASCIIEncoding().GetBytes(hwid));
                }
                catch (Exception expr_4C)
                {
                    ProjectData.SetProjectError(expr_4C);
                    getHwid = BackHwid();
                    ProjectData.ClearProjectError();
                }
                return getHwid;
            }

            public static string GetMd5Hash(MD5 md5Hash, string input)
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                checked
                {
                    var num = data.Length - 1;
                    for (var i = 0; i <= num; i++)
                        sBuilder.Append(data[i].ToString("x2"));
                    return sBuilder.ToString();
                }
            }

            public static string getServerVariable(string VariableName)
            {
                try
                {
                    var webRequest = (WebRequest)NewLateBinding.LateGet(null, typeof(WebRequest), "Create", new[]
                    {
                    Operators.AddObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Convert.ToString(Convert.ToString(string.Concat(WebPath, WebApiPath, SecretToken, WebAppApi, AppToken, "/")) + LicenseKey + "/") + VariableName + "/", AppCheckSum), "/"), TesterToken), ".xml")
                }, null, null, null);
                    webRequest.Timeout = 60000;
                    webRequest.Proxy = null;
                    var response = webRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var xmlDocument = new XmlDocument();

                    var flag = responseStream == null;
                    if (flag)
                    {
                        return Convert.ToString(false);
                    }
                    xmlDocument.Load(responseStream);

                    var xmlNode = xmlDocument.SelectSingleNode("//response/Status");
                    var flag2 = xmlNode == null;
                    if (flag2)
                    {
                        return Convert.ToString(false);
                    }
                    var innerText = xmlNode.InnerText;

                    var xmlNode2 = xmlDocument.SelectSingleNode("//response/_integrity");
                    var flag3 = xmlNode2 == null;
                    if (flag3)
                    {
                        return Convert.ToString(false);
                    }

                    var innerText2 = xmlNode2.InnerText;
                    var xmlNode3 = xmlDocument.SelectSingleNode("//response/updated_on");
                    var flag4 = xmlNode3 == null;
                    if (flag4)
                    {
                        return Convert.ToString(false);
                    }
                    var str = Decrypt(xmlNode3.InnerText);

                    var xmlNode4 = xmlDocument.SelectSingleNode("//response/created_on");
                    var flag5 = xmlNode4 == null;
                    if (flag5)
                    {
                        return Convert.ToString(false);
                    }
                    var str2 = Decrypt(xmlNode4.InnerText);

                    var xmlNode5 = xmlDocument.SelectSingleNode("//response/variable_value");
                    var flag6 = xmlNode5 == null;
                    if (flag6)
                    {
                        return Convert.ToString(false);
                    }
                    var text = Decrypt(xmlNode5.InnerText);

                    var length = (Convert.ToString(text + str2) + str).Length;
                    response.Close();
                    responseStream.Close();
                    var flag7 = !string.Equals(GetHash(Convert.ToString(length)), innerText2, StringComparison.CurrentCultureIgnoreCase);
                    if (flag7)
                    {
                        return Convert.ToString(false);
                    }
                    if (Operators.CompareString(innerText, "VALID", false) == 0)
                    {
                        return text;
                    }
                    if (Operators.CompareString(innerText, "INVALID", false) != 0)
                    {
                        ErrorMessage(Operators.CompareString(innerText, "EMERGENCY", false) != 0
                            ? "03:Bad Request"
                            : "02:ACCESS IS RESTRICTED,TRY AGAIN LATER");
                    }
                    else
                    {
                        ErrorMessage("01:Forbidden Error");
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                return null;
            }

            private static object hash_generator(string hashType, string fileName)
            {
                var flag = Operators.CompareString(hashType.ToLower(), "md5", false) == 0;
                object instance;
                if (flag)
                {
                    instance = MD5.Create();
                }
                else
                {
                    var flag2 = Operators.CompareString(hashType.ToLower(), "sha1", false) == 0;
                    if (flag2)
                    {
                        instance = SHA1.Create();
                    }
                    else
                    {
                        var flag3 = Operators.CompareString(hashType.ToLower(), "sha256", false) == 0;
                        if (!flag3)
                        {
                            Interaction.MsgBox("Unknown type of hash : " + hashType, MsgBoxStyle.Critical, null);
                            return false;
                        }
                        instance = SHA256.Create();
                    }
                }
                var fileStream = File.OpenRead(fileName);
                fileStream.Position = 0L;
                object[] array;
                bool[] array2;
                var obj = NewLateBinding.LateGet(instance, null, "ComputeHash", array = new object[]
                {
                fileStream
                }, null, null, array2 = new[]
                {
                true
                });
                if (array2[0])
                {
                    fileStream = (FileStream)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(FileStream));
                }
                var hashValue = (byte[])obj;
                var objectValue = RuntimeHelpers.GetObjectValue(PrintByteArray(hashValue));
                fileStream.Close();
                return objectValue;
            }

            private static string Identifier(string wmiClass, string wmiProperty)
            {
                var result = "";
                var mc = new ManagementClass(wmiClass);
                var moc = mc.GetInstances();
                var enumerator = moc.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var mo = (ManagementObject)enumerator.Current;
                    var flag = Operators.CompareString(result, "", false) == 0;
                    if (!flag) continue;
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch (Exception expr53)
                    {
                        ProjectData.SetProjectError(expr53);
                        ProjectData.ClearProjectError();
                    }
                }
                return result;
            }

            private static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
            {
                var result = "";
                var mc = new ManagementClass(wmiClass);
                var moc = mc.GetInstances();
                var enumerator = moc.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var mo = (ManagementObject)enumerator.Current;
                    var flag = Operators.CompareString(mo[wmiMustBeTrue].ToString(), "True", false) == 0;
                    if (!flag) continue;
                    var flag2 = Operators.CompareString(result, "", false) == 0;
                    if (!flag2) continue;
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch (Exception expr74)
                    {
                        ProjectData.SetProjectError(expr74);
                        ProjectData.ClearProjectError();
                    }
                }
                return result;
            }

            private static bool LicenseIntegrityCheck()
            {
                var length = string.Concat(LicenseKey, Status, LicenseCreatedOn, LicenseActivatedOn, LicenseExpirationDate, LicenseExpirationDateDayLeft, LicenseNote, CustomerName, CustomerEmail, CustomerPhone, DeviceCountry, RuleName, RuleTime, RuleDevice, DeviceUsed, DeviceName, DeviceCountry, DeviceIp).Length;
                var authenticated = Authenticated;
                bool licenseIntegrityCheck;
                if (authenticated)
                {
                    var b = _integrity.ToUpper();
                    licenseIntegrityCheck = string.Equals(GetHash(Convert.ToString(length)), b, StringComparison.CurrentCultureIgnoreCase);
                }
                else
                {
                    ErrorMessage("05:Unauthorized");
                    licenseIntegrityCheck = false;
                }
                return licenseIntegrityCheck;
            }

            private static string MacId()
            {
                return Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
            }

            private static byte[] Md5Hash(string value)
            {
                return new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(value));
            }

            public static object Md5_hash(string fileName)
            {
                return hash_generator("md5", fileName);
            }

            private static string Pack(string text)
            {
                checked
                {
                    var x = 0;
                    foreach (var n in text)
                    {
                        var y = 0;
                        y++;
                        x += Strings.Asc(n) * y;
                    }
                    var retVal = x + "00000000";
                    return retVal.Substring(0, 8);
                }
            }

            private static object PrintByteArray(byte[] array)
            {
                var hexValue = "";
                checked
                {
                    var num = array.Length - 1;
                    for (var i = 0; i <= num; i++)
                        hexValue += array[i].ToString("X2");
                    return hexValue.ToUpper();
                }
            }

            public static object sha_1(string fileName)
            {
                return hash_generator("sha1", fileName);
            }

            private static object sha_256(string fileName)
            {
                return hash_generator("sha256", fileName);
            }

            public static void Start()
            {
                var @object = new ThreadWithState(null, new CallBack(Worker));
                new Thread(@object.ThreadProc)
                {
                    IsBackground = true
                }.Start();
            }

            public static string Systemcheck()
            {
                InitializeSecurity = CreateRandomPassword(32);
                try
                {
                    var webRequest = (WebRequest)NewLateBinding.LateGet(null, typeof(WebRequest), "Create", new[]
                    {
                    Operators.AddObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(WebPath, WebApiPath, SecretToken, Checksum, AppToken, "/"), AppCheckSum), "/"), TesterToken), "/"), InitializeSecurity), ".xml")
                }, null, null, null);
                    webRequest.Timeout = 60000;
                    webRequest.Proxy = null;
                    var response = webRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var xmlDocument = new XmlDocument();
                    var flag = responseStream != null;
                    if (flag)
                    {
                        xmlDocument.Load(responseStream);
                        var xmlNode = xmlDocument.SelectSingleNode("//response/value");
                        var flag2 = xmlNode != null;
                        if (flag2)
                        {
                            var innerText = xmlNode.InnerText;
                            var flag3 = Operators.CompareString(BASE64_Encode(InitializeSecurity), innerText, false) == 0;
                            if (flag3)
                            {
                                response.Close();
                                responseStream.Close();
                                return Convert.ToString(RuntimeHelpers.GetObjectValue(BASE64_Decode(innerText)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                return null;
            }
            private static string VideoId()
            {
                return Identifier("Win32_VideoController", "DriverVersion") + Identifier("Win32_VideoController", "Name");
            }
            public static string Livesystemcheck()
            {
                try
                {
                    var webRequest = (WebRequest)NewLateBinding.LateGet(null, typeof(WebRequest), "Create", new[]
                    {
                    Operators.AddObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(WebPath, WebApiPath, SecretToken, WebLiveSystem, AppToken, "/", LicenseKey, "/"), AppHwid), "/"), AppCheckSum), "/"), GetOSName()), "/"), GetUICultureDisplayName()), "/"), GetOSPlatform()), ".xml")
                }, null, null, null);
                    webRequest.Timeout = 60000;
                    webRequest.Proxy = null;
                    var response = webRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var xmlDocument = new XmlDocument();
                    var flag = responseStream != null;
                    if (flag)
                    {
                        xmlDocument.Load(responseStream);
                        var xmlNode = xmlDocument.SelectSingleNode("//response/Status");
                        var flag2 = xmlNode != null;
                        if (flag2)
                        {
                            var innerText = xmlNode.InnerText;
                            response.Close();
                            responseStream.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                return null;
            }
            private static void Worker(Thread thread1)
            {
                var newthread = new ThreadWithState(Thread.CurrentThread, Worker);
                if (thread1 == null)
                {
                    thread1 = new Thread(newthread.ThreadProc) { IsBackground = true };
                    thread1.Start();
                }

                bool flag2;
                var mutex = new Mutex(false, AppDomain.CurrentDomain.FriendlyName, out flag2); //This is NOT used anywhere!!! Check it again Tony!!! LOL

                var Generator = new Random();
                while (true)
                {


                    var randtime = Generator.Next(150000, 240000);
                    if (!flag2)
                    {
                        if (Authenticated)
                        {
                            Livesystemcheck();
                            CheckLicense(LicenseKey);
                        }
                        else
                        {
                            Systemcheck();
                        }
                    }
                    Thread.Sleep(randtime);
                }
            }

            public static string Éëê(string àåå)
            {
                const string ééë = "7ZSTJK+W=cVtBCasyf0gzA8uvwDEq3XH/1RMNOILPQU4klm65YbdeFrx2hij9nopG";
                var ôõö = new StringBuilder();
                checked
                {
                    var i = 0;
                    do
                    {
                        var ìíì = new int[4];
                        var chrs = new int[3];
                        var b = 0;
                        do
                        {
                            ìíì[b] = ééë.IndexOf(àåå[i]);
                            i++;
                            b++;
                        } while (b <= 3);
                        chrs[0] = (ìíì[0] << 2) | (ìíì[1] >> 4);
                        chrs[1] = ((ìíì[1] & 15) << 4) | (ìíì[2] >> 2);
                        chrs[2] = ((ìíì[2] & 3) << 6) | ìíì[3];
                        ôõö.Append(Strings.Chr(chrs[0]));
                        var flag = ìíì[2] != 64;
                        if (flag)
                            ôõö.Append(Strings.Chr(chrs[1]));
                        var flag2 = ìíì[3] != 64;
                        if (flag2)
                            ôõö.Append(Strings.Chr(chrs[2]));
                    } while (i < àåå.Length);
                    return ôõö.ToString();
                }
            }

            public static string Éõö(string ôåå)
            {
                var ôíì = "cdtyBou87FGT340LKdeAqCLo";
                var ìëê = "B56GDE0VH7S1";
                var àëê = "SHA1";
                var àõö = Conversions.ToString(2);
                var àíì = "OFRna73m*aze01xY";
                var ôëê = 256;
                var flag = string.IsNullOrEmpty(ôåå);
                checked
                {
                    string éõö;
                    if (flag)
                    {
                        éõö = "";
                    }
                    else
                    {
                        var ìåå = Encoding.ASCII.GetBytes(àíì);
                        var ìõö = Encoding.ASCII.GetBytes(ìëê);
                        var éåå = Convert.FromBase64String(ôåå);
                        DeriveBytes éíì = new PasswordDeriveBytes(ôíì, ìõö, àëê, Conversions.ToInteger(àõö));
                        var êåå = éíì.GetBytes((int)Math.Round(ôëê / 8.0));
                        var êíì = new RijndaelManaged { Mode = CipherMode.CBC };
                        var êõö = new byte[éåå.Length - 1 + 1];
                        int ëêà;
                        using (var õöà = êíì.CreateDecryptor(êåå, ìåå))
                        {
                            using (var íìà = new MemoryStream(éåå))
                            {
                                using (var ëêô = new CryptoStream(íìà, õöà, CryptoStreamMode.Read))
                                {
                                    ëêà = ëêô.Read(êõö, 0, êõö.Length);
                                    íìà.Close();
                                    ëêô.Close();
                                }
                            }
                        }
                        êíì.Clear();
                        éõö = Encoding.UTF8.GetString(êõö, 0, ëêà);
                    }
                    return éõö;
                }
            }

    
            /*private static string _appurl;

            private static string _appVersion;

            private static string _appVersionDescription;

            private static bool _authenticated;

            private static string _customerCountry;

            private static string _customerEmail;

            private static string _customerName;

            private static string _customerPhone;

            private static string _deviceCountry;

            private static string _deviceIp;

            private static string _deviceName;

            private static string _deviceUsed;

            private static string _initializeSecurity;

            private static string _integrity;

            private static string _licenseKey;

            private static string _licenseActivatedOn;

            private static string _licenseCreatedOn;

            private static string _licenseExpirationDate;

            private static string _licenseExpirationDateDayLeft;

            private static string _licenseNote;

            private static string _ruleDevice;

            private static string _ruleName;

            private static string _ruleTime;

            private static string _secretToken;

            private static string _slogan;

            private static string _status;

            private static string _subDomain;

            private static string _testerToken;

            private static string _appName;

            private static string _appToken;*/
        }
    }
}
