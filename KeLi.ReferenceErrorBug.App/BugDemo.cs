/*
 * MIT License
 *
 * Copyright(c) 2020 KeLi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

/*
             ,---------------------------------------------------,              ,---------,
        ,----------------------------------------------------------,          ,"        ,"|
      ,"                                                         ,"|        ,"        ,"  |
     +----------------------------------------------------------+  |      ,"        ,"    |
     |  .----------------------------------------------------.  |  |     +---------+      |
     |  | C:\>FILE -INFO                                     |  |  |     | -==----'|      |
     |  |                                                    |  |  |     |         |      |
     |  |                                                    |  |  |/----|`---=    |      |
     |  |              Author: KeLi                          |  |  |     |         |      |
     |  |              Email: kelicto@protonmail.com         |  |  |     |         |      |
     |  |              Creation Time: 10/21/2020 12:26:12 PM |  |  |     |         |      |
     |  | C:\>_                                              |  |  |     | -==----'|      |
     |  |                                                    |  |  |   ,/|==== ooo |      ;
     |  |                                                    |  |  |  // |(((( [66]|    ,"
     |  `----------------------------------------------------'  |," .;'| |((((     |  ,"
     +----------------------------------------------------------+  ;;  | |         |,"
        /_)_________________________________________________(_/  //'   | +---------+
           ___________________________/___  `,
          /  oooooooooooooooo  .o.  oooo /,   \,"-----------
         / ==ooooooooooooooo==.o.  ooo= //   ,`\--{)B     ,"
        /_==__==========__==_ooo__ooo=_/'   /___________,"
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace KeLi.ReferenceErrorBug.App
{
    public class BugDemo
    {
        public static void AddDebugingGroup<T>(T element) where T : Animal
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));
        }

        public static void AddDebugingGroup(IEnumerable<AnimalId> elementIds)
        {
            if (elementIds is null)
                throw new ArgumentNullException(nameof(elementIds));
        }

        public static void AddDebugingGroup(IEnumerable<Animal> elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            AddDebugingGroup(elements.Select(s => s.Id).ToList());
        }

        public static void AddDebugingGroup<T>(IEnumerable<T> elements) where T : Animal
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            AddDebugingGroup(elements.Select(s => s.Id).ToList());
        }

        public static void AddDebugingGroup(Func<IEnumerable<AnimalId>> func)
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            var elementIds = func.Invoke().Where(w => w != null).ToList();

            AddDebugingGroup(elementIds);
        }
    }

    public class Animal
    {
        public AnimalId Id { get; set; }
    }

    public class Bird : Animal
    {
        public void Fly()
        {
            Console.WriteLine("I can fly.");
        }
    }

    public class AnimalId
    {
        public int IntegerValue { get; set; }
    }
}