﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FubuCore.Reflection;
using FubuMVC.Core.UI;

namespace HtmlTags.AspNet.Mvc.Conventions
{
    public class DefaultAspNetMvcHtmlConventions : DefaultHtmlConventions
    {
        public DefaultAspNetMvcHtmlConventions()
        {
            // Labels
            Labels.ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));
            Labels.IfPropertyIs<bool>()
                .ModifyWith(er => er.CurrentTag.Text(er.OriginalTag.Text() + "?"));


            // Checkboxes
            Editors.IfPropertyIs<bool>().Attr("type", "checkbox");

            // Color
            //Editors.IfPropertyIs<Color>().Attr("type", "color");

            // Date TODO: bring in Noda time
            //Editors.IfPropertyIs<LocalDate>().Attr("type", "date");
            //Editors.IfPropertyIs<LocalTime>().Attr("type", "time");
            //Editors.IfPropertyIs<LocalDateTime>().Attr("type", "datetime-local");
            //Editors.IfPropertyIs<OffsetDateTime>().Attr("type", "datetime");

            // Email
            Editors.If(er => er.Accessor.Name.Contains("Email"))
                .Attr("type", "email");

            // Hidden
            Editors.IfPropertyIs<Guid>().Attr("type", "hidden");
            Editors.IfPropertyIs<Guid?>().Attr("type", "hidden");
            Editors.IfPropertyHasAttribute<HiddenInputAttribute>().Attr("type", "hidden");

            Editors.IfPropertyIs<decimal?>().ModifyWith(m =>
                m.CurrentTag.Data("pattern", "9{1,9}.99").Data("placeholder", "0.00"));



            // Password Conventions
            Editors.If(er => er.Accessor.Name.Contains("Password")).Attr("type", "password");
            Editors.If(er =>
            {
                var attr = er.Accessor.GetAttribute<DataTypeAttribute>();
                return attr != null && attr.DataType == DataType.Password;
            }).Attr("type", "password");

            Editors.Modifier<EnumDropDownModifier>();
        }
    }
}