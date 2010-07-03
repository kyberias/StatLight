﻿using System;
using StatLight.Core.WebServer.XapHost;

namespace StatLight.Core.Configuration
{
    public class ServerTestRunConfiguration
    {
        private readonly Func<byte[]> _xapToTextFactory;

        public ServerTestRunConfiguration(byte[] xapHost, long dialogSmackDownElapseMilliseconds, string xapToTest, XapHostType xapHostType, Func<byte[]> xapToTextFactory)
        {
            _xapToTextFactory = xapToTextFactory;
            if (xapHost == null) throw new ArgumentNullException("xapHost");
            if (xapToTest == null) throw new ArgumentNullException("xapToTest");

            HostXap = xapHost;
            DialogSmackDownElapseMilliseconds = dialogSmackDownElapseMilliseconds;
            XapToTestPath = xapToTest;
            XapHostType = xapHostType;
        }

        public long DialogSmackDownElapseMilliseconds { get; private set; }
        public byte[] HostXap { get; private set; }
        public byte[] XapToTest { get { return _xapToTextFactory(); } }
        public string XapToTestPath { get; private set; }
        public XapHostType XapHostType { get; private set; }
    }
}