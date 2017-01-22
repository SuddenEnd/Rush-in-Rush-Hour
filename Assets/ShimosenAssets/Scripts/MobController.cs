using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour {

	private TimeManager TimeMng;
	private GameObject[] targets;
	private GameObject target;
	private Transform myTfm;
	private Vector3 newTargetPos;
	private bool isRide1;
	private bool isRide2;
	private float speed;

	private UnityEngine.AI.NavMeshAgent agent;

	void Start() {
		TimeMng = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		speed = 2.0f;
		myTfm = transform;
		targets = GameObject.FindGameObjectsWithTag("Target");
		// 一番距離の近いターゲットを取得する
		float sqrDist = 999.9f;	// 暫定の遠い値
		foreach (GameObject target in targets) {
		//Debug.Log(target.name);
			if (((myTfm.position - target.transform.position).sqrMagnitude) < sqrDist) {
				this.target = target;
				sqrDist = (myTfm.position - target.transform.position).sqrMagnitude;
			}
		}

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update() {
		// 第1目的地へ
		if (isRide1 && agent.enabled) {
			//Debug.Log("hoge1");
			agent.SetDestination(target.transform.position);
		}else if(isRide1 && !agent.enabled){
			// 乗り遅れたら死ぬのさ(精度悪い)
			if (myTfm.position.x <= -0.9f && !TimeMng.Running) {
				Destroy(gameObject);
			}
			//Debug.Log(myTfm.position.x);
		}
		// 第2目的地へ
		if (isRide2) {
			//Debug.Log("hoge2");
			myTfm.position = Vector3.MoveTowards(myTfm.position, newTargetPos, speed * Time.deltaTime);
		}



		// デバッグ用
		if (Input.GetKeyDown(KeyCode.O)) {
			RideTrain();
		}
	}

	// 電車に乗り込み開始するメソッド
	public void RideTrain() {
		isRide1 = true;
		agent.enabled = true;
		//myTfm.SetParent(null);
	}

	void OnCollisionEnter(Collision col) {
		if (!isRide2) {
			// 最初のターゲットに接触したら、第2目的地へ
			if (col.gameObject.CompareTag("Target")) {

				//isRide1 = false;
				isRide2 = true;
				agent.enabled = false;

				// 電車内の範囲を設定
				float x = Random.Range(-0.8f, 0.65f);
				float y = Random.Range(0.5f, 0.5f);
				float z = Random.Range(-6.5f, 6.5f);

				// 第2目的の座標を生成
				newTargetPos = new Vector3(x, y, z);
			}

			// 乗り込んだMobは車両の子要素になる
			if (col.gameObject.CompareTag("Stage")) {
				myTfm.SetParent(col.transform.parent.parent);
			}
		}
	}

}
