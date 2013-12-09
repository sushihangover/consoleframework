﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Binding.Converters
{
    /**
 * Converter between String and Integer.
 *
 * @author igor.kostromin
 *         26.06.13 19:37
 */
public class StringToIntegerConverter : IBindingConverter {
    public Type FirstType {
        get { return typeof ( String ); }
    }

    public Type SecondType {
        get { return typeof ( int ); }
    }

    public ConversionResult Convert(Object s) {
        try {
            if (s == null) return new ConversionResult( false, "String is null");
            int value = int.Parse(( string ) s);
            return new ConversionResult(value);
        } catch (FormatException e) {
            return new ConversionResult(false, "Incorrect number");
        }
    }

    public ConversionResult ConvertBack(Object integer) {
        return new ConversionResult(((int)integer).ToString(CultureInfo.InvariantCulture) );
    }
}

}
