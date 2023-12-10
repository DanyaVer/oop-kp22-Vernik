﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_6.Data.ChainOfResponsibility
{
    public interface IChecker
    {
        IChecker SetNext(IChecker checker);

        Task<bool> CheckPaper(Paper studentPaper);

        void DisplayChain();
    }
}
