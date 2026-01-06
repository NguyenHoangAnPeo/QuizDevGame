using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IQuizDataProvider
{
   Task<Subject> LoadSubject(string subjectKey);
}
