﻿using FarsiToolbox;
using Xunit;

namespace FarsiToolboxTests
{
    public class TextCleanerTests
    {
        [Fact]
        public void ReplaceYeKaf()
        {
            Assert.Equal("علی بانکی", "علي بانكي".ReplaceYeKaf());
        }

        [Fact]
        public void ReplaceRedundantWhitespace()
        {
            var originalStr = "وب جزیی از اینترنت است. وب مخزنی از صفحات  اینترنتی است که هر یک دارای آدرس مشخصی هستند" +
                "و توسط آن آدرس‌ها مسیریابی یا یافته میگردند\t  \t و کاربری که به شبکه اینترنت متصل شده (کامپیوتر آنها" +
                " جزو  کامپیوترهای دیگر اینترنت قرار  گرفته  است)\t\tمی‌توانند با نوشتن آدرس صفحه ای از وب، برروی نوار" +
                "آدرس مرورگر خود، به صفحه وب مورد نظر که در مخزن صفحات \t\tوب   در  اینترنت                                قرار دارد، دسترسی   یابد.";

            var expectedStr = "وب جزیی از اینترنت است. وب مخزنی از صفحات اینترنتی است که هر یک دارای آدرس مشخصی هستند" +
                "و توسط آن آدرس‌ها مسیریابی یا یافته میگردند و کاربری که به شبکه اینترنت متصل شده (کامپیوتر آنها" +
                " جزو کامپیوترهای دیگر اینترنت قرار گرفته است) می‌توانند با نوشتن آدرس صفحه ای از وب، برروی نوار" +
                "آدرس مرورگر خود، به صفحه وب مورد نظر که در مخزن صفحات وب در اینترنت قرار دارد، دسترسی یابد.";

            Assert.Equal(expectedStr, originalStr.ReplaceRedundantWhitespace());
        }
    }
}
