﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Bookie.Common.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime? DatePublished { get; set; }
        public int? Pages { get; set; }
        public int Rating { get; set; }

        public string FullPathAndFileName { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<BookMark> BookMarks { get; set; }
        public virtual Cover Cover { get; set; }
        public virtual Source Source { get; set; }

        [NotMapped]
        public ImageSource Image
        {
            get
            {
                if (Cover != null && !String.IsNullOrEmpty(Cover.FileName))
                {
                    return new BitmapImage(new Uri("ms-appdata:///local/Covers/" + this.Cover.FileName));
                }
                else
                {
                    return new BitmapImage(new Uri("ms-appdata:///local/Covers/nocover.png"));
                }

            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Abstract: {Abstract}, DatePublished: {DatePublished}, Pages: {Pages}, FullPathAndFileName: {FullPathAndFileName}, FileName: {FileName}, BookMarks: {BookMarks}, Cover: {Cover}, Source: {Source}";
        }
    }
}
