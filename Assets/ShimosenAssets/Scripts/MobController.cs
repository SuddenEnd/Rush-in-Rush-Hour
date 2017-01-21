using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour {

	private GameObject[] targets;
	private GameObject target;
	private Transform myTfm;
	private Vector3 newTargetPos;
	private bool isRide;
	private bool isRide2;
	private float speed;

	private UnityEngine.AI.NavMeshAgent agent;

	void Start() {
		speed = 5.0f;
		myTfm = transform;
		targets = GameObject.FindGameObjectsWithTag("Target");

		// 一番距離の近いターゲットを取得する
		float sqrDist = 99.9f;	// 暫定の遠い値
		foreach (GameObject target in targets) {
			if (((myTfm.position - target.transform.position).sqrMagnitude) < sqrDist) {
				this.target = target;
				sqrDist = (myTfm.position - target.transform.position).sqrMagnitude;
			}
		}

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update() {
		// 第1目的地へ
		if (isRide) {
			agent.SetDestination(target.transform.position);
		}
		// 第2目的地へ
		if (isRide2) {
			myTfm.position = Vector3.MoveTowards(myTfm.position, newTargetPos, speed * Time.deltaTime);
		}

		// デバッグ用
		if (Input.GetKeyDown(KeyCode.O)) {
			RideTrain();
		}
	}

	// 電車に乗り込み開始するメソッド
	public void RideTrain() {
		isRide = true;
		agent.enabled = true;
		myTfm.SetParent(null);
	}

	void OnCollisionEnter(Collision col) {

		// 最初のターゲットに接触したら、第2目的地へ
		if (col.gameObject.CompareTag("Target")) {

			isRide2 = true;

			// 電車内の範囲を設定
			float x = Random.Range(-0.8f, 0.65f);
			float y = Random.Range(0.5f, 0.5f);
			float z = Random.Range(-6.5f, 6.5f);
			
			// 第2目的の座標を生成
			newTargetPos = new Vector3(x, y, z);
		}
	}

}
