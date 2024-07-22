//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using UnityEngine.UI;

//namespace W2D2.Test
//{
//    class Player
//    {
//        public int Icon { get; private set; }
//        public string Name { get; private set; }
//        public Texture Texture { get; private set; }
//        public IAttackAlgo AttackAlgo { get; private set; }


//        public class Builder
//        {
//            IAttackAlgo _attackAlgo;
//            int _icon;


//            public Builder WithAttackAlgo(IAttackAlgo algo)
//            {
//                _attackAlgo = algo;
//                return this;
//            }

//            public Builder WithIcon(int icon)
//            {
//                _icon = icon;
//                return this;
//            }

//            public Player Build()
//            {
//                return new Player()
//                {
//                    Icon = _icon,
//                    AttackAlgo = _attackAlgo,
//                    Name = "name",
//                    Texture = null
//                };
//            }
//        }
//    }



//    class ImageProxy
//    {
//        readonly string _filePath;


//        public ImageProxy(string filePath)
//        {

//            var builder = new Player.Builder().WithAttackAlgo(null).WithIcon(0);


//            var player = builder.Build();
//            builder.WithIcon(44);
//            var playerWithIcon44 = builder.Build();

//            new Player(isd)
//            _filePath = filePath;
//        }


//        public Texture2D GetData()
//        {
//            var bytes = File.ReadAllBytes(_filePath);
//            tex = ..

//            return tex;
//        }
//    }



//    class PlayerData
//    {
//        public string Name;
//        public int Level;
//        public ImageProxy Icon;
//    }


//    abstract class NavAlgo
//    {
//        public abstract void Compute();
//        public abstract void Run();
//        public abstract void Print();
//    }


//    class MyNavAlgo : NavAlgo
//    {
//        public override void Compute()
//        {
//            new PlayerData();
//            new PlayerData();
//            new PlayerData();
//            new PlayerData();
//            new PlayerData();
//        }
//    }

//    class MyNavAlgo2 : NavAlgo
//    {
//        public override void Compute()
//        {
//            ibasdn

//                as
//                decimalasd
//        }
//    }

//    class MyNavAlgo3 : NavAlgo
//    {
//        public override void Compute()
//        {
//            ibasdn

//                as
//                decimalasd
//        }
//    }



//    abstract class PizzaState
//    {
//        public abstract void Execute();
//    }


//    class NewState : PizzaState
//    {
//        public override void Execute()
//        {
//            var a = new MyNavAlgo();
//            var b = new MyNavAlgo2();
//            var c = new MyNavAlgo3();

//            Fn(c);

//            throw new NotImplementedException();
//        }


//        void Fn(NavAlgo na)
//        {
//            na.Compute();
//        }
//    }

//    class ApprovedState : PizzaState
//    {
//        public override void Execute()
//        {
//            throw new NotImplementedException();
//        }

//    }

//    class DeliveredState : PizzaState
//    {
//        public override void Execute()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    class Executor
//    {
//        PizzaState[] _statesSequence = new PizzaState[] { new NewState(), new ApprovedState(), new DeliveredState() };
//        int _curState = -1;


//        PizzaState AdvanceToNextState()
//        {
//            _curState++;
//            var state = _statesSequence[_curState];

//            return state;
//        }

//        public void Do()
//        {
//            var curState = AdvanceToNextState();
//            curState.Execute();
//        }
//    }


//    interface IWeatherObserver
//    {
//        void OnTemperatureUpdated(int temp);
//    }


//    class WeatherSource : MonoBehaviour
//    {
//        List<IWeatherObserver> _observers;


//        public void Subscribe(IWeatherObserver observer)
//        {
//            _observers.Add(observer);
//        }


//        void Update()
//        {
//            if (changed)
//            {
//                int temp = GetTemp();
//                foreach (var observer in _observers)
//                {
//                    if (observer != null)
//                    {
//                        observer.OnTemperatureUpdated(temp);
//                    }
//                }
//            }
//        }

//    }


//    class WeatherTemperatureIndicatorUI : MonoBehaviour, IWeatherObserver
//    {
//        [SerializeField] TMPro.TextMeshProUGUI _tempText;


//        public void OnTemperatureUpdated(int temp)
//        {
//            _tempText.text = temp + "";
//        }
//    }

//    class C : MonoBehaviour
//    {
//        [SerializeField] WeatherTemperatureIndicatorUI indicator;


//        void Start()
//        {
//            var wo = GetComponent<WeatherSource>();
//            wo.Subscribe(indicator);
//        }

//    }




//    interface IUnit
//    {
//        int Health { get; }
//        void Attack();
//    }

//    interface INavAlgo
//    {
//        int Compute();
//    }


//    class ShortestPathAlgo : INavAlgo
//    {
//        public int Compute()
//        {
//        }
//    }


//    class CheapestPathAlgo : INavAlgo
//    {
//        public int Compute()
//        {
//        }
//    }


//    class AlgoChooser
//    {
//        public INavAlgo Choose(bool isRich)
//        {
//            if (isRich)
//                return new ShortestPathAlgo();

//             return new CheapestPathAlgo();
//        }
//    }





//    class SugarAdder
//    {
//        public void AddSugar()
//        {

//            var algo = new AlgoChooser().Choose(isRich: true);

//            int path = algo.Compute();
//        }
//    }

//    class WaterSource
//    {
//        const int STATE_IDLE = 1;
//        const int STATE_STARTING = 2;
//        const int STATE_IN_PROGRESS = 3;
//        const int STATE_STOPPING = 4;


//        public void PourWater()
//        {
//            var x = State.IDLE;

//            var xx = STATE_IDLE;


//            var speed = x * STATE_STOPPING
//        }
//    }


//    enum State
//    {
//        IDLE,
//        STARTING,
//        STOPPING
//    }


//    class CoffeeMachine
//    {
//        MoneyGrabber mg;
//        SugarAdder sg;
//        WaterSource ws;


//        public static CoffeeMachine CreateDefault()
//        {
//            return new CoffeeMachine
//        }


//        public CoffeeMachine(MoneyGrabber mg, SugarAdder sg, WaterSource ws)
//        {
//            this.mg = mg;
//            this.sg = sg;
//            this.ws = ws;
//        }


//        public void DoCoffee()
//        {
//            mg.GrabMoney();
//            sg.AddSugar();
//            ws.PourWater();
//        }
//    }


//    class VerySpecialCoffeeMachine : CoffeeMachine
//    {
//        MoneyGrabber mg;
//        WaterSource ws;


//        public CoffeeMachine(MoneyGrabber mg, WaterSource ws)
//        {
//            this.mg = mg;
//            this.ws = ws;
//        }


//        public void DoCoffee()
//        {
//            mg.GrabMoney();
//            thing.Something();
//            ws.PourWater();
//        }
//    }


//    public class NewClass : MonoBehaviour
//    {
//        public bool isAlive;
//        public GameObject prefab;
//        int[] items = new int[] { -1, 0, 1, 2, 3, 4 };


//        public void Count()
//        {

//            int a = MyF(2);
//            //StartCoroutine(PrintAlive());
//            int step = 4;
//            for (int i = 0; i < items.Length; i += 2)
//            {
//                var item = items[i];
//                Debug.Log("At intex " + i + " value is " + item);
//            }

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }

//            int a = MyF(2);
//            int a = MyF(2);
//            //StartCoroutine(PrintAlive());
//            int step = 4;
//            for (int i = 0; i < items.Length; i += 2)
//            {
//                var item = items[i];
//                Debug.Log("At intex " + i + " value is " + item);
//            }
//            //StartCoroutine(PrintAlive());
//            int step = 4;
//            for (int i = 0; i < items.Length; i += 2)
//            {
//                var item = items[i];
//                Debug.Log("At intex " + i + " value is " + item);

//                Reset(2, 3);
//            }

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }

//            int a = MyF(2);
//        }

//        private void Reset()
//        {

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }

//            int a = MyF(2);
//            int a = MyF(2);
//            //StartCoroutine(PrintAlive());
//            int step = 4;
//            for (int i = 0; i < items.Length; i += 2)
//            {
//                var item = items[i];
//                Debug.Log("At intex " + i + " value is " + item);
//            }

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }

//            int a = MyF(2);
//            int a = MyF(2);
//        }

//        public void PrintItems()
//        {

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }
//        }

//        int MyF(int b)
//        {
//            return 3 * (b + 3);

//        }

//        IEnumerator PrintAlive()
//        {
//            int a = MyF(2);

//            do
//            {
//                Debug.Log("I'm alive!");
//                yield return null;
//            }
//            while (isAlive);
//        }
//    }
//}

//using System;
//using System.Collections;
//using UnityEngine;

//namespace W2D2.Test
//{

//    class Enemy
//    {
//        public virtual void Attack()
//        {
//            Debug.Log("10");
//        }
//    }

//    class BossEnemy : Enemy
//    {
//        public override void Attack()
//        {
//            Debug.Log("20");
//        }
//    }


//    ///



//    class MoneyGrabber
//    {
//        public void GrabMoney()
//        {
//            Enemy curEnemy = null;

//            var e = new Enemy();
//            e.Attack();
//            curEnemy = e;
//            curEnemy.Attack();

//            var be = new BossEnemy();
//            be.Attack();
//            curEnemy = be;
//            curEnemy.Attack();
//        }
//    }

//    class SugarAdder
//    {
//        public void AddSugar()
//        {

//        }
//    }

//    class WaterSource
//    {
//        public void PourWater()
//        {

//        }
//    }

//    class CoffeeMachine
//    {
//        MoneyGrabber mg;
//        SugarAdder sg;
//        WaterSource ws;

//        public static CoffeeMachine CreateDefault()
//        {
//            return new CoffeeMachine
//        }


//        public CoffeeMachine(MoneyGrabber mg, SugarAdder sg, WaterSource ws)
//        {
//            this.mg = mg;
//            this.sg = sg;
//            this.ws = ws;
//        }


//        public void DoCoffee()
//        {
//            mg.GrabMoney();
//            sg.AddSugar();
//            ws.PourWater();
//        }
//    }


//    class VerySpecialCoffeeMachine : CoffeeMachine
//    {
//        MoneyGrabber mg;
//        WaterSource ws;


//        public CoffeeMachine(MoneyGrabber mg, WaterSource ws)
//        {
//            this.mg = mg;
//            this.ws = ws;
//        }


//        public void DoCoffee()
//        {
//            mg.GrabMoney();
//            thing.Something();
//            ws.PourWater();
//        }
//    }


//    public class NewClass : MonoBehaviour
//    {
//        public bool isAlive;
//        public GameObject prefab;
//        int[] items = new int[] { -1, 0, 1, 2, 3, 4 };


//        public void Count()
//        {

//            int a = MyF(2);
//            //StartCoroutine(PrintAlive());
//            int step = 4;
//            for (int i = 0; i < items.Length; i += 2)
//            {
//                var item = items[i];
//                Debug.Log("At intex " + i + " value is " + item);
//            }

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }

//            int a = MyF(2);
//        }

//        public void PrintItems()
//        {

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }
//        }

//        int MyF(int b)
//        {
//            return 3 * (b + 3);

//        }

//        IEnumerator PrintAlive()
//        {
//            int a = MyF(2);

//            do
//            {
//                Debug.Log("I'm alive!");
//                yield return null;
//            }
//            while (isAlive);
//        }
//    }
//}

//using System;
//using System.Collections;
//using UnityEngine;

//namespace W2D2.Test
//{

//    class Enemy
//    {
//        public virtual void Attack()
//        {
//            Debug.Log("10");
//        }
//    }

//    class BossEnemy : Enemy
//    {
//        public override void Attack()
//        {
//            Debug.Log("20");
//        }
//    }


//    ///



//    class MoneyGrabber
//    {
//        public void GrabMoney()
//        {
//            Enemy curEnemy = null;

//            var e = new Enemy();
//            e.Attack();
//            curEnemy = e;
//            curEnemy.Attack();

//            var be = new BossEnemy();
//            be.Attack();
//            curEnemy = be;
//            curEnemy.Attack();
//        }
//    }

//    class SugarAdder
//    {
//        public void AddSugar()
//        {

//        }
//    }

//    class WaterSource
//    {
//        public void PourWater()
//        {

//        }
//    }

//    class CoffeeMachine
//    {
//        MoneyGrabber mg;
//        SugarAdder sg;
//        WaterSource ws;

//        public static CoffeeMachine CreateDefault()
//        {
//            return new CoffeeMachine
//        }


//        public CoffeeMachine(MoneyGrabber mg, SugarAdder sg, WaterSource ws)
//        {
//            this.mg = mg;
//            this.sg = sg;
//            this.ws = ws;
//        }


//        public void DoCoffee()
//        {
//            mg.GrabMoney();
//            sg.AddSugar();
//            ws.PourWater();
//        }
//    }


//    class VerySpecialCoffeeMachine : CoffeeMachine
//    {
//        MoneyGrabber mg;
//        WaterSource ws;


//        public CoffeeMachine(MoneyGrabber mg, WaterSource ws)
//        {
//            this.mg = mg;
//            this.ws = ws;
//        }


//        public void DoCoffee()
//        {
//            mg.GrabMoney();
//            thing.Something();
//            ws.PourWater();
//        }
//    }


//    public class NewClass : MonoBehaviour
//    {
//        public bool isAlive;
//        public GameObject prefab;
//        int[] items = new int[] { -1, 0, 1, 2, 3, 4 };


//        public void Count()
//        {

//            int a = MyF(2);
//            //StartCoroutine(PrintAlive());
//            int step = 4;
//            for (int i = 0; i < items.Length; i += 2)
//            {
//                var item = items[i];
//                Debug.Log("At intex " + i + " value is " + item);
//            }

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }

//            int a = MyF(2);
//        }

//        public void PrintItems()
//        {

//            foreach (var item in items)
//            {
//                Debug.Log("Item is " + item);
//            }
//        }

//        int MyF(int b)
//        {
//            return 3 * (b + 3);

//        }

//        IEnumerator PrintAlive()
//        {
//            int a = MyF(2);

//            do
//            {
//                Debug.Log("I'm alive!");
//                yield return null;
//            }
//            while (isAlive);
//        }
//    }
//}

