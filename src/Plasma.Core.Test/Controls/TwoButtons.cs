/* **********************************************************************************
 *
 * Copyright (c) Microsoft Corporation. All rights reserved.
 *
 * This source code is subject to terms and conditions of the Microsoft Permissive
 * License (MS-PL).
 *
 * You must not remove this notice, or any other, from this software.
 *
 * **********************************************************************************/
using NUnit.Framework;
using OpenQA.Selenium;

namespace Plasma.Core.Test.Controls
{
    [TestFixture]
    public class TwoButtons
    {
        [Test]
        public void TwoButtons_Test()
        {
            /////////////////////////////////////////////////////////////////////////////
            // Initial request for TwoButton.aspx page

            AspNetResponse firstResponse = WebApplicationFixture.ProcessRequest("~/Controls/TwoButton.aspx");


            /////////////////////////////////////////////////////////////////////////////
            // Test Pushing Button1 with value in TextBox

            AspNetForm form = firstResponse.GetForm();
            form["TextBox1"] = "Testing";

            AspNetResponse secondResponse = WebApplicationFixture.ProcessRequest(Button.Click(form, "Button1"));

            Assert.AreEqual("Value: Testing", secondResponse.FindElement(By.Id("Label1")).InnerHtml());


            /////////////////////////////////////////////////////////////////////////////
            // Test Pushing Button2 on TwoButton.aspx

            form = secondResponse.GetForm();

            AspNetResponse thirdResponse = WebApplicationFixture.ProcessRequest(Button.Click(form, "Button2"));

            Assert.AreEqual("Selected", thirdResponse.FindElement(By.Id("Label1")).GetAttribute("class"));
        }
    }
}
