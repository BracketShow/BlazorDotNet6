using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;

namespace BlazorDotNet6.NativeCode
{
    public partial class NativeCodePage
    {
        [DllImport("Test")]
        static extern int fact(int n);

        [DllImport("Add")]
        static extern int add(int n1, int n2);

        private int n1 = 0;
        private int n2 = 0;
        private int result = 0;

        private void OnN1Change(ChangeEventArgs args)
        {
            if (!int.TryParse(args.Value?.ToString(), out var number)) return;

            n1 = number;
            CalculateSum();
        }

        private void OnN2Change(ChangeEventArgs args)
        {
            if (!int.TryParse(args.Value?.ToString(), out var number)) return;

            n2 = number;
            CalculateSum();
        }

        private void CalculateSum() => result = add(n1, n2);
    }
}