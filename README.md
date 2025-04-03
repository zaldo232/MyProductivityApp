<h1> 할 일 관리, 일정 캘린더, 계산기</h1>

## 주요 기능

### To-Do 리스트
- 할 일 추가 / 삭제 / 완료 체크
- JSON 파일로 로컬 저장/불러오기
- `ObservableCollection`, `ICommand`, `INotifyPropertyChanged` 기반 MVVM 연습

### 캘린더 일정 관리
- 날짜별 일정 추가/삭제
- 현재 날짜 일정만 필터링해서 표시
- 일정 데이터 JSON 저장/불러오기 지원

### 계산기
- 기본 사칙연산 + 괄호 입력
- 계산 이력 자동 저장
- WPF `UniformGrid` 기반 버튼 배열
- `System.Data.DataTable`을 활용한 실시간 수식 계산

---

## 기술 스택

- **언어**: C#
- **프레임워크**: .NET 8 (WPF)
- **패턴**: MVVM (Model-View-ViewModel)
- **라이브러리**: XAML 기본 컨트롤 활용
- **데이터 저장**: JSON 파일 (System.Text.Json)

